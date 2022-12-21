using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using WebApplication1.Models.EFModels;

namespace WebApplication1.Models.Repositories
{
    public class RegisterRepository
    {
        private AppDbContext db = new AppDbContext();
        public void Create(Register register)
        {
            db.Registers.Add(register);
            db.SaveChanges();
        }
        public List<Register> GetAll()
        {
            return db.Registers.ToList();
        }
        public Register FindByEmail(string email)
        {
            return db.Registers.FirstOrDefault(x => x.Email == email);
        }
        public Register FindById(int id)
        {
            return db.Registers.Find(id);
        }
    }
}