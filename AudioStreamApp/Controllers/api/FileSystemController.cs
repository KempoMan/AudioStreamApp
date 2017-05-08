using System.IO;
using System.Linq;
using System.Web.Http;
using AudioStreamApp.Models;

namespace AudioStreamApp.Controllers.api
{
    public class FileSystemController : ApiController
    {
        public const string RootDir = @"I:\mp3"; //TODO: convert to config entry

        [Route("api/filesystem/getartists")]
        public IHttpActionResult GetArtists(string letter = "0")
        {
            var dirs = Directory.GetDirectories(RootDir, $"{letter}*");
            var result = dirs.Select(r => new Artist{ Name = Path.GetFileName(r) }).ToList();

            return Ok(result);
        }

        [Route("api/filesystem/getalbums")]
        public IHttpActionResult GetAlbums(string artist)
        {
            var dirs = Directory.GetDirectories($@"{RootDir}\{artist}", "*.*");
            var result = dirs.Select(r => new Album { AlbumName = Path.GetFileName(r), ArtistName = artist }).ToList();

            return Ok(result);
        }

        [Route("api/filesystem/getsongs")]
        public IHttpActionResult GetSongs([FromUri]Album album)
        {
            var dirs = new DirectoryInfo($@"{RootDir}\{album.ArtistName}\{album.AlbumName}");

            var result = dirs.GetFiles("*.mp3")
                .Select(r => new
                {
                    r.Name,
                    r.Directory,
                    r.DirectoryName,
                    r.FullName,
                    r.Length,
                    Artist = TagLib.File.Create(r.FullName).Tag.FirstAlbumArtist,
                    Album = TagLib.File.Create(r.FullName).Tag.Album,
                    Title = TagLib.File.Create(r.FullName).Tag.Title
                })
                .ToList();

            return Ok(result);
        }
    }
}
