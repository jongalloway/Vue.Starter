namespace Vue.Starter.Api;
using Vue.Starter.Data;

public static class Content{

  public static void MapRoutes(IEndpointRouteBuilder app)
  {
    //just need to load this once, here. If you use this in other 
    //routes, consider turning it into an injectable service
    var lib = new ContentLibrary().Load();


    app.MapGet("api/about/", () => lib.Documents.First(d => d.Slug == "About"));
    app.MapGet("api/terms/", () => lib.Documents.First(d => d.Slug == "Terms"));
    app.MapGet("api/privacy/", () => lib.Documents.First(d => d.Slug == "Privacy"));

    //you can separate these into their own methods if you need to
    //the / route launches the SPA Proxy so you won't see it
    app.MapGet("api/content/{dir}", (string dir) => {
      Console.WriteLine("Incoming Request", dir);
      var docs = lib.Documents.Where(d => d.Directory.ToLower() == dir.ToLower());
      return docs;
    });
    
  }
  
}