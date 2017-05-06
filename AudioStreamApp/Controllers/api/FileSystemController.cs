using System.IO;
using System.Linq;
using System.Web.Http;


namespace AudioStreamApp.Controllers.api
{
    public class FileSystemController : ApiController
    {
        public const string RootDir = @"I:\mp3"; //TODO: convert to config entry

        public IHttpActionResult GetArtists(string letter)
        {
            var dirs = Directory.GetDirectories(RootDir, $"{letter}*");
            var result = dirs.Select(Path.GetFileName).ToList();

            return Ok(result);
        }

        public IHttpActionResult GetAlbums(string artist)
        {
            return NotFound();
        }

    }
}
