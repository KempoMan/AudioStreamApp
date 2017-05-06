using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;
using AudioStreamApp.Models;


namespace AudioStreamApp.Controllers.api
{

    public class FileSystemController : ApiController
    {
        public const string RootDir = @"I:\mp3"; //TODO: convert to config entry

        public IHttpActionResult GetArtists(string letter = "0")
        {
            var dirs = Directory.GetDirectories(RootDir, $"{letter}*");
            var result = dirs.Select(r => new Artist{ Name = Path.GetFileName(r) }).ToList();

            return Ok(result);
        }

        //public IEnumerable<string> GetSongs(Album album)
        //{
            
        //}

        public IEnumerable<Album> GetAlbums(string artist)
        {
            var dirs = Directory.GetDirectories($@"{RootDir}\{artist}", "*.*");
            var result = dirs.Select(r => new Album { AlbumName = Path.GetFileName(r), ArtistName = artist }).ToList();

            return result;
        }
    }
}
