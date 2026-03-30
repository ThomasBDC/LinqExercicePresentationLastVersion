using DataSources;
using System.Xml.Linq;

// Exo 1 - Select
/*ListAlbumsData.ListAlbums
    .Select(album => $"Album n°{album.AlbumId} : {album.Title}")
    .ToList()
    .ForEach(Console.WriteLine);*/


// Exo 3 - Where + Join + GroupBy
/*Console.WriteLine("\nQuel est votre recherche ?");
string recherche = Console.ReadLine();

ListAlbumsData.ListAlbums
    .Where(album => album.Title.Contains(recherche, StringComparison.InvariantCultureIgnoreCase))
    .Join(ListArtistsData.ListArtists, album => album.ArtistId, artist => artist.ArtistId, 
        (album, artist) => new { artist, album })
    .GroupBy(x => x.artist.Name)
    .ToList()
    .ForEach(group =>
    {
        Console.WriteLine($"Artiste : {group.Key}");
        group.ToList().ForEach(x => Console.WriteLine($"Album n°{x.album.AlbumId} : {x.album.Title}"));
    });*/

// Exo 4 - Pagination
/*int pageSize = 20;
int pageNumber = 0;
bool continuer = true;

while (continuer)
{
    ListAlbumsData.ListAlbums
        .OrderBy(album => album.AlbumId)
        .Skip(pageNumber * pageSize)
        .Take(pageSize)
        .ToList()
        .ForEach(album => Console.WriteLine($"Album n°{album.AlbumId} : {album.Title}"));

    int totalPages = (int)Math.Ceiling((double)ListAlbumsData.ListAlbums.Count / pageSize);

    Console.WriteLine($"\nPage {pageNumber + 1}/{totalPages}");
    if (pageNumber < totalPages - 1)
    {
        Console.WriteLine("Entrée pour continuer");
        Console.ReadLine();
        pageNumber++;
    }
    else
    {
        continuer = false;
    }
}*/

// Exo 5 - Transform to XML
var albumsXml = new XElement("Root",
    ListAlbumsData.ListAlbums
        .Select(album => new XElement("Album",
            new XElement("AlbumId", album.AlbumId),
            new XElement("Title", album.Title)
        ))
);

Console.WriteLine(albumsXml);