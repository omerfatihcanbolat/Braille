using Braille.DAL.Context;
using Braille.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Braille.DAL.EntitiyFramework
{
    public class KelimeDAL
    {
        ApplicationContext db = new ApplicationContext();
        public IEnumerable<Kelimeler> GetKelimeler()
        {
            return db.Kelimeler;
        }

        public Kelimeler GetKelimeById(int id)
        {
            return db.Kelimeler.Find(id);
        }

        public Kelimeler InsertKelime(Kelimeler kelime)
        {
            db.Kelimeler.Add(kelime);
            db.SaveChanges();
            return kelime;
        }
        public Kelimeler UpdateKelime(int id, Kelimeler kelime)
        {
            db.Entry(kelime).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return kelime;
        }

        public void DeleteKelime(int id)
        {
            db.Kelimeler.Remove(db.Kelimeler.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyKelime(int id)
        {
            return db.Kelimeler.Any(x => x.KelimeId == id);
        }
    }
}
