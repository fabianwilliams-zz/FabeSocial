using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using FabeSocial.DataObjects;
using FabeSocial.Models;

namespace FabeSocial.Controllers
{
    public class SocialItemController : TableController<SocialItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<SocialItem>(context, Request, Services);
        }

        // GET tables/SocialItem
        public IQueryable<SocialItem> GetAllSocialItem()
        {
            return Query(); 
        }

        // GET tables/SocialItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<SocialItem> GetSocialItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/SocialItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<SocialItem> PatchSocialItem(string id, Delta<SocialItem> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/SocialItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public async Task<IHttpActionResult> PostSocialItem(SocialItem item)
        {
            SocialItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/SocialItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteSocialItem(string id)
        {
             return DeleteAsync(id);
        }

    }
}