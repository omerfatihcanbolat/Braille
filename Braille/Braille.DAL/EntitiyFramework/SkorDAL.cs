using Braille.DAL.Context;
using Braille.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

        public void InsertSkorList(List<Skor> skorList)
        {
            foreach (var item in skorList)
            {
                var oldScore = db.Skorlar
                    .Where(a => a.KelimeId == item.KelimeId && a.Telefon.Equals(item.Telefon))
                    .FirstOrDefault();
                if(oldScore == null)
                {
                    //insert
                    db.Skorlar.Add(item);
                }
                else if (oldScore.Sure > item.Sure)
                {
                    var cloneDate = oldScore;
                    //update
                    oldScore.Sure = item.Sure;
                    db.Skorlar.AddOrUpdate(oldScore);
                }
               
            }
            db.SaveChanges();
        }

        public IQueryable<Skor> GetUserScores(string phoneId)
        {
            return db.Skorlar.Where(a=>a.Telefon.Equals(phoneId));
        }

        public int GetKelimeSiralama(string phoneId, int kelimeId)
        {
            var tumSiralama = db.Skorlar.Where(a=> a.KelimeId == kelimeId)
                .OrderBy(a=>a.Sure).ToList();


            for (int i = 0; i < tumSiralama.Count; i++)
            {
                var item = tumSiralama[i];
                if(item.Telefon == phoneId)
                {
                   return i+1;                 
                }
            }
            return 0;
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
