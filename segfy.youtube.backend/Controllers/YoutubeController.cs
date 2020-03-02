using System;
using System.Collections.Generic;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Microsoft.AspNetCore.Mvc;
using segfy.youtube.backend.Models;
using segfy.youtube.backend.Repository;

namespace segfy.youtube.backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YoutubeController : ControllerBase
    {
        private readonly ISearchLogRepository _repository;

        public YoutubeController(ISearchLogRepository repository) 
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<SearchTerm> Get(int offset = 0, int limit = 10) => _repository.GetSearch(offset, limit);

        [HttpGet("{id}")]
        public SearchTerm GetLog(int id) => _repository.GetSearch(id);


        [HttpPost]
        public SearchTerm Post([FromBody]SearchRequest request)
        {
            var searchTerm = new SearchTerm
            {
                SearchedAt = DateTime.Now,
                Term = request.Term
            };

            var youtube = new YouTubeService(
                new Google.Apis.Services.BaseClientService.Initializer() {
                    ApiKey = "AIzaSyDfEOoWTX0fTlfkOru4k2ZPDXOQYZmp-J0"
                }
            );

            var listRequest = youtube.Search.List("snippet");
            listRequest.Q = request.Term;
            listRequest.Order = SearchResource.ListRequest.OrderEnum.Relevance;
            var searchResponse = listRequest.Execute();
            var videos = new List<SearchLog>();

            foreach (SearchResult searchResult in searchResponse.Items)
            {
                if (searchResult.Id.Kind.Equals("youtube#video"))
                {
                    var log = new SearchLog { 
                        VideoId = searchResult.Id.VideoId, 
                        VideoTitle = searchResult.Snippet.Title,
                        PublishedAt = searchResult.Snippet.PublishedAt,
                        ChannelId = searchResult.Snippet.ChannelId,
                        ChannelTitle = searchResult.Snippet.ChannelTitle,
                        Description = searchResult.Snippet.Description,
                        Thumbnails = searchResult.Snippet.Thumbnails.Default__.Url,
                    };
                    searchTerm.SearchLog.Add(log);
                }
            }
            _repository.SaveSearch(searchTerm);
            return searchTerm;
        }

        [HttpDelete("{id}")]
        public void Delete(int id) => _repository.DeleteSearch(id);

        [HttpPut]
        public void Put(SearchLog log) => _repository.UpdateSearch(log);
    }
}