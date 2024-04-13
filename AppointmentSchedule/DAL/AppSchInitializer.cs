using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AppointmentSchedule.Models;

namespace AppointmentSchedule.DAL
{
    public class AppSchInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AppSchContext>
    {
        protected override void Seed(AppSchContext context)
        {
            var clients = new List<Client>
            {
            new Client{FirstName="CFirst1",LastName="CLast1",PhoneNumber="0526990901"},
            new Client{FirstName="CFirst2",LastName="CLast2",PhoneNumber="0526990902"},
            new Client{FirstName="CFirst3",LastName="CLast3",PhoneNumber="0526990903"},
            new Client{FirstName="CFirst4",LastName="CLast4",PhoneNumber="0526990904"},
            new Client{FirstName="CFirst5",LastName="CLast5",PhoneNumber="0526990905"},
            new Client{FirstName="CFirst6",LastName="CLast6",PhoneNumber="0526990906"},
            new Client{FirstName="CFirst7",LastName="CLast7",PhoneNumber="0526990907"}
            };

            clients.ForEach(s => context.Clients.Add(s));
            context.SaveChanges();

            var workers = new List<Worker>
            {
            new Worker{FirstName="WAFirst1",LastName="WALast1",PhoneNumber="0545540001",IsActive=true},
            new Worker{FirstName="WMFirst2",LastName="WMLast2",PhoneNumber="0545540002",IsActive=true},
            new Worker{FirstName="WMFirst3",LastName="WMLast3",PhoneNumber="0545540003",IsActive=true},
            new Worker{FirstName="WFirst4",LastName="WLast4",PhoneNumber="0545540004",IsActive=true},
            new Worker{FirstName="WFirst5",LastName="WLast5",PhoneNumber="0545540005",IsActive=true},
            new Worker{FirstName="WFirst6",LastName="WLast6",PhoneNumber="0545540006",IsActive=true},
            new Worker{FirstName="WFirst7",LastName="WLast7",PhoneNumber="0545540007",IsActive=true}
            };
            workers.ForEach(s => context.Workers.Add(s));
            context.SaveChanges();

            var appointments = new List<Appointment>
            {
            new Appointment{ClientID=1,WorkerID=8,Status=Status.Done,AppointmentDateTime=new DateTime(2020,3,11,9,43,00),TextBox="First"},
            new Appointment{ClientID=2,WorkerID=8,Status=Status.Done,AppointmentDateTime=new DateTime(2020,3,12,10,15,00),TextBox="Second"},
            new Appointment{ClientID=1,WorkerID=9,Status=Status.Canceled,AppointmentDateTime=new DateTime(2020,3,12,9,43,00),TextBox="Third"},
            new Appointment{ClientID=3,WorkerID=9,Status=Status.NoShow,AppointmentDateTime=new DateTime(2020,3,12,14,41,00)},
            new Appointment{ClientID=1,WorkerID=10,Status=Status.Done,AppointmentDateTime=new DateTime(2020,3,13,9,43,00),TextBox="Fifth"},
            new Appointment{ClientID=4,WorkerID=9,Status=Status.Done,AppointmentDateTime=new DateTime(2020,3,13,10,43,00)},
            new Appointment{ClientID=5,WorkerID=10,Status=Status.Canceled,AppointmentDateTime=new DateTime(2020,3,13,11,43,00),TextBox="testy 7"},
            new Appointment{ClientID=1,WorkerID=11,Status=Status.Done,AppointmentDateTime=new DateTime(2020,3,13,12,43,00)},
            new Appointment{ClientID=6,WorkerID=11,Status=Status.Done,AppointmentDateTime=new DateTime(2020,3,14,9,43,00)},
            new Appointment{ClientID=1,WorkerID=12,Status=Status.Confirmed,AppointmentDateTime=new DateTime(2020,3,15,9,43,00),TextBox="10 it is"},
            new Appointment{ClientID=2,WorkerID=9,Status=Status.Pending,AppointmentDateTime=new DateTime(2020,3,16,9,43,00)},
            new Appointment{ClientID=1,WorkerID=11,Status=Status.Pending,AppointmentDateTime=new DateTime(2020,3,17,9,43,00)},
            new Appointment{ClientID=4,WorkerID=10,Status=Status.Confirmed,AppointmentDateTime=new DateTime(2020,3,17,9,43,00),TextBox="wordswordswords"}
            };
            appointments.ForEach(s => context.Appointments.Add(s));
            context.SaveChanges();

            var users = new List<User>
            {
                new User{IsActive=true,Username="Admin",Password="Admin"},
                new User{IsActive=true,Username="Username2",Password="Password2"},
                new User{IsActive=true,Username="Username3",Password="Password3"},
                new User{IsActive=true,Username="Username4",Password="Password4"}
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var roles = new List<Role>
            {
                new Role{RoleName="Admin"},   //access to everything
                new Role{RoleName="UserControl"},  //access to adding users, giving/taking roles and setting users inactive
                new Role{RoleName="AppointmentControl"}, //full control over appointments
                new Role{RoleName="AppointmentEnd"},    //can edit appointment after it happened, can comment on it and change the status
                new Role{RoleName="ClientControl"},     //can add and edit clients 
                new Role{RoleName="WorkerControl"}  //can add and edit workers
            };
            roles.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();

            var userRoleMaps = new List<UserRoleMap>
            {
                new UserRoleMap{UserID=1,RoleID=1},
                new UserRoleMap{UserID=1,RoleID=2},
                new UserRoleMap{UserID=1,RoleID=3},
                new UserRoleMap{UserID=1,RoleID=4},
                new UserRoleMap{UserID=1,RoleID=5},
                new UserRoleMap{UserID=1,RoleID=6},
                new UserRoleMap{UserID=2,RoleID=2},
                new UserRoleMap{UserID=2,RoleID=3},
                new UserRoleMap{UserID=2,RoleID=4},
                new UserRoleMap{UserID=2,RoleID=5},
                new UserRoleMap{UserID=2,RoleID=6},
                new UserRoleMap{UserID=3,RoleID=3},
                new UserRoleMap{UserID=3,RoleID=4},
                new UserRoleMap{UserID=3,RoleID=5},
                new UserRoleMap{UserID=4,RoleID=5}
            };
            userRoleMaps.ForEach(s => context.UserRoleMaps.Add(s));
            context.SaveChanges();
        }
    }
}