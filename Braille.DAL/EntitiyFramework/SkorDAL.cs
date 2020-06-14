using Braille.DAL.Context;
using Braille.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Braille.DAL.EntitiyFramework
{
    public class SkorDAL
    {
        ApplicationContext db = new ApplicationContext();
        public IEnumerable<Skor> GetSkorlar()
        {
            return db.Skorlar;
        }

        public Skor GeSkorById(int id)
        {
            return db.Skorlar.Find(id);
        }

        public Skor InsertSkor(Skor skor)
        {
            db.Skorlar.Add(skor);
            db.SaveChanges();
            return skor;
        }

        public Skor UpdateSkor(int id, Skor skor)
        {
            db.Entry(skor).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return skor;
        }

        public void DeleteSkor(int id)
        {
            db.Skorlar.Remove(db.Skorlar.Find(id));
            db.SaveChanges();
        }


        public bool IsThereAnySkor(int id)
        {
            return db.Skorlar.Any(x => x.SkorId == id);
        }
    }



}
