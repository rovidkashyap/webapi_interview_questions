using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace default_mediatype_supported.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        #region DEFAULT MEDIA-TYPE SUPPORTED BY ASP.NET WEB API (NON-CORE)

        // 1. JSON - 
        //          Media-Type: `application/json`
        //          Formatter: `JsonMediaTypeFormatter`
        //          Description: This formatter uses JSON.NET to serialize and deserialize data to and 
        //                      from JSON format. It is default formatter in ASP.Net Web API.

        // 2. XML -
        //          Media-Type: `application/xml`, `text/xml`
        //          Formatter: `XmlMediaTypeFormatter`
        //          Description: This formatter uses `DataContractSerializer` to serialize and deserialize
        //                      data to and from XML format.

        // 3. Form URL-Encoded -
        //          Media-Type: `application/x-www-urlencoded`
        //          Formatter: `FormUrlEncodedMediaTypeFormatter`
        //          Description: This formatter handles URL-encoded form data, typically used with HTML forms.

        // 4. BSON -
        //          Media-Type: `application/bson`
        //          Formatter: `BsonMediaTypeFormatter`
        //          Description: This formatter handles BSON (Binary JSON) format, which is binary
        //                      representation of JSON-like documents.

        #endregion

        #region DEFAULT MEDIA-TYPE SUPPORTED BY ASP.NET Core Web API (Core)

        // 1. JSON -
        //          Media-Type: `application/json`
        //          Formatter: `System.Text.Json.JsonSerializer` (default) or `Newtonsoft.Json.JsonConvert`
        //                      if `AddNewtonsoftJson` is used
        //          Description: By Default, ASP.Net Core uses `System.Text.Json` for JSON serialization and
        //                      deserialization. However you can configure it to use `Newtonsoft.Json`.

        // 2. XML -
        //          Media-Type: `application/xml`, `text/xml`
        //          Formatter: `XmlSerializerOutputFormatter`
        //          Description: This formatter uses `XmlSerializer` to serialize and deserializer data
        //                      to and from XML format.

        // 3. Form URL-Encoded -
        //          Media-Type: `application/x-www-form-urlencoded`
        //          Formatter: `SystemTextInputFormatter` (for handling form data in controllers)
        //          Description: This formatter handles URL-encoded form data.

        // 4. Plain Text -
        //          Media-Type: `Text/plain`
        //          Formatter: `TextOutputFormatter`
        //          Description: This formatter handles plain text data.

        #endregion
    }
}
