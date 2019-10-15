using BlueBadge.Data;
using BlueBadge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Services
{
    public class HotlineService
    {
        public bool CreateHotline(HotlineCreate model)
        {
            var entity =
               new Hotline()
               {
                   Name = model.Name,
                   PhoneNumber = model.PhoneNumber,
                   Website = model.Website,
                   IsTextFriendly = model.IsTextFriendly,
                   IsMultilingual = model.IsMultilingual,
                   Details = model.Details
               };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Hotlines.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<HotlineListItem> GetHotlines()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Hotlines
                    .Select(
                        e =>
                            new HotlineListItem
                            {
                                HotlineId = e.HotlineId,
                                Name = e.Name,
                                PhoneNumber = e.PhoneNumber,
                                Website = e.Website
                            }
                        );

                return query.ToArray();
            }
        }

        public HotlineDetail GetHotlineById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Hotlines
                    .Single(e => e.HotlineId == id);
                return
                    new HotlineDetail
                    {
                        HotlineId = entity.HotlineId,
                        Name = entity.Name,
                        PhoneNumber = entity.PhoneNumber,
                        Website = entity.Website,
                        IsTextFriendly = entity.IsTextFriendly,
                        IsMultilingual = entity.IsMultilingual,
                        Details = entity.Details
                    };
            }
        }

        public bool UpdateHotline(HotlineEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Hotlines
                    .Single(e => e.HotlineId == model.HotlineId);
                
                entity.Name = model.Name;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Website = model.Website;
                entity.IsTextFriendly = model.IsTextFriendly;
                entity.IsMultilingual = model.IsMultilingual;
                entity.Details = model.Details;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteHotline(int hotlineId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Hotlines
                    .Single(e => e.HotlineId == hotlineId);

                ctx.Hotlines.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
