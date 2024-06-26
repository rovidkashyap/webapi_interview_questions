using Microsoft.AspNetCore.Mvc;

namespace hateos_in_restful_api.Controllers
{
    public static class LinkGenerator
    {
        public static List<Link> GenerateLinks(int id, IUrlHelper urlHelper)
        {
            return new List<Link>
                {
                    new Link
                    {
                        Href = urlHelper.Link(nameof(ProductController.GetProductById), new { id }),
                        Rel = "self",
                        Method = "GET"
                    },
                    new Link
                    {
                        Href = urlHelper.Link(nameof(ProductController.UpdateProduct), new { id }),
                        Rel = "update_product",
                        Method = "PUT"
                    },
                    new Link
                    {
                        Href = urlHelper.Link(nameof(ProductController.DeleteProduct), new { id }),
                        Rel = "delete_product",
                        Method = "DELETE"
                    }
                };
        }
    }
}
