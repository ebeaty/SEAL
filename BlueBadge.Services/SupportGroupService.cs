using BlueBadge.Data;
using BlueBadge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Services
{
    public class SupportGroupService
    {
        public bool CreateSupportGroup(SupportGroupCreate model)
        {
            var entity =
                new SupportGroup()
                {
                    Name = model.Name,
                    Location = model.Location,
                    PhoneNumber = model.PhoneNumber,
                    Website = model.Website,
                    Details = model.Details
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.SupportGroups.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SupportGroupListItem> GetSupportGroups()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .SupportGroups
                    .Select(
                        e =>
                        new SupportGroupListItem
                        {
                            SupportGroupId = e.SupportGroupId,
                            Name = e.Name,
                            Location = e.Location,
                            PhoneNumber = e.PhoneNumber
                        }
                        );

                return query.ToArray();
            }
        }

        public SupportGroupDetail GetSupportGroupById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SupportGroups
                    .Single(e => e.SupportGroupId == id);
                return
                    new SupportGroupDetail
                    {
                        SupportGroupId = entity.SupportGroupId,
                        Name = entity.Name,
                        Location = entity.Location,
                        PhoneNumber = entity.PhoneNumber,
                        Website = entity.Website,
                        Details = entity.Details
                    };
            }
        }

        public bool UpdateSupportGroup(SupportGroupEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SupportGroups
                    .Single(e => e.SupportGroupId == model.SupportGroupId);

                entity.Name = model.Name;
                entity.Location = model.Location;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Website = model.Website;
                entity.Details = model.Details;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSupportGroup(int supportgroupId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SupportGroups
                    .Single(e => e.SupportGroupId == supportgroupId);

                ctx.SupportGroups.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
