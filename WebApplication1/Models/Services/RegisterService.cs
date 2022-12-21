using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.EFModels;
using WebApplication1.Models.Repositories;

namespace WebApplication1.Models.Services
{
    public class RegisterService
    {
        private RegisterRepository repository = new RegisterRepository();
        
        public void Create(Register register)
        {
            // 驗證 Email 是否已經存在
            // var dataInDb = db.Registers.FirstOrDefault(x => x.Email == register.Email);
            var dataInDb = repository.FindByEmail(register.Email);

            if (dataInDb != null)    //  表示資料已存在
            {
                throw new Exception("這個 Email 已經存在");
                //ModelState.AddModelError("Email", "這個 Email 已經存在");
            }

            // 用程式指定建檔時間，而不是用使用者輸入
            register.CreatedTime = DateTime.Now;

            repository.Create(register);
            //db.Registers.Add(register);
            //db.SaveChanges();
        }    
        public Register Find(int id)
        {
            //Register register = db.Registers.Find(id);
            Register register = repository.FindById(id);
            if (register == null)
            {
                throw new Exception("找不到指定的紀錄");
            }
            return register;
        }
    
    }
}