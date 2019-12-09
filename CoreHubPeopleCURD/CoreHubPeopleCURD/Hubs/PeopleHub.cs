using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreHubPeopleCURD.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace CoreHubPeopleCURD.Hubs
{
    public class PeopleHub : Hub
    {
        public readonly PersonContext db;

        public PeopleHub(IServiceProvider sp)
        {
            db = sp.GetRequiredService<PersonContext>();
        }
        //public PeopleHub(PersonContext _db)
        //{
        //    this.db = _db;
        //}
        public override async Task OnConnectedAsync()
        {
            try
            {
                await Clients.Caller.SendAsync("PersonIndex", db.People.ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public async Task GetPerson(int id)
        {
            try
            {
                await Clients.Caller.SendAsync("PersonInfo", db.People.Find(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public async Task RemovePerson(int id)
        {
            try
            {

                var model = db.People.Find(id);

                if (model != null)
                {
                    db.People.Remove(model);
                    db.SaveChanges();
                }
                await Clients.All.SendAsync("PersonIndex", db.People.ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public async Task SubmitPerson(Person model)
        {
            try
            {
                if (model.Id == 0)
                {
                    db.People.Add(model);
                }
                else
                {
                    db.Entry(model).State = EntityState.Modified;
                }
                await db.SaveChangesAsync();
                await Clients.All.SendAsync("PersonIndex", db.People.ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}
