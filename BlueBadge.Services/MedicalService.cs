using BlueBadge.Data;
using BlueBadge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Services
{
    public class MedicalService
    {
        public bool CreateMedical(MedicalCreate model)
        {
            var entity =
                new Medical()
                {
                    Name = model.Name,
                    Location = model.Location,
                    PhoneNumber = model.PhoneNumber,
                    Website = model.Website,
                    FinancialAid = model.FinancialAid,
                    Details = model.Details
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Medicals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MedicalListItem> GetMedicals()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Medicals
                    .Select(
                        e =>
                        new MedicalListItem
                        {
                            MedicalId = e.MedicalId,
                            Name = e.Name,
                            Location = e.Location,
                            PhoneNumber = e.PhoneNumber,
                            Website = e.Website,
                            FinancialAid = e.FinancialAid,
                            Details = e.Details
                        }
                        );
                return query.ToArray();
            }
        }

        public MedicalDetail GetMedicalById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Medicals
                    .Single(e => e.MedicalId == id);
                return
                    new MedicalDetail
                    {
                        MedicalId = entity.MedicalId,
                        Name = entity.Name,
                        Location = entity.Location,
                        PhoneNumber = entity.PhoneNumber,
                        Website = entity.Website,
                        FinancialAid = entity.FinancialAid,
                        Details = entity.Details
                    };
            }
        }

        public bool UpdateMedical(MedicalEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Medicals
                    .Single(e => e.MedicalId == model.MedicalId);

                entity.Name = model.Name;
                entity.Location = model.Location;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Website = model.Website;
                entity.FinancialAid = model.FinancialAid;
                entity.Details = model.Details;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMedical(int medicalId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Medicals
                    .Single(e => e.MedicalId == medicalId);

                ctx.Medicals.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
