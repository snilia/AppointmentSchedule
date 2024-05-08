using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AppointmentSchedule.Models;

namespace AppointmentSchedule.DAL
{
    //public class AppSchInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AppSchContext>
    public class AppSchInitializer : System.Data.Entity.DropCreateDatabaseAlways<AppSchContext>
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
            /*  old appointments, without appointment length
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
            */

            var appointments = new List<Appointment>
            {
                new Appointment{ClientID=1, WorkerID=8, Status=Status.Done, AppointmentDateTime=new DateTime(2020,3,11,9,43,00), LengthInHours=2, TextBox="First"},
                new Appointment{ClientID=2, WorkerID=8, Status=Status.Done, AppointmentDateTime=new DateTime(2020,3,12,10,15,00), LengthInHours=1, TextBox="Second"},
                new Appointment{ClientID=1, WorkerID=9, Status=Status.Canceled, AppointmentDateTime=new DateTime(2020,3,12,9,43,00), LengthInHours=1, TextBox="Third"},
                new Appointment{ClientID=3, WorkerID=9, Status=Status.NoShow, AppointmentDateTime=new DateTime(2020,3,12,14,41,00), LengthInHours=3},
                new Appointment{ClientID=1, WorkerID=10, Status=Status.Done, AppointmentDateTime=new DateTime(2020,3,13,9,43,00), LengthInHours=2, TextBox="Fifth"},
                new Appointment{ClientID=4, WorkerID=9, Status=Status.Done, AppointmentDateTime=new DateTime(2020,3,13,10,43,00), LengthInHours=2},
                new Appointment{ClientID=5, WorkerID=10, Status=Status.Canceled, AppointmentDateTime=new DateTime(2020,3,13,11,43,00), LengthInHours=1, TextBox="testy 7"},
                new Appointment{ClientID=1, WorkerID=11, Status=Status.Done, AppointmentDateTime=new DateTime(2020,3,13,12,43,00), LengthInHours=1},
                new Appointment{ClientID=6, WorkerID=11, Status=Status.Done, AppointmentDateTime=new DateTime(2020,3,14,9,43,00), LengthInHours=4},
                new Appointment{ClientID=1, WorkerID=12, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2020,3,15,9,43,00), LengthInHours=1, TextBox="10 it is"},
                new Appointment{ClientID=2, WorkerID=9, Status=Status.Pending, AppointmentDateTime=new DateTime(2020,3,16,9,43,00), LengthInHours=3},
                new Appointment{ClientID=1, WorkerID=11, Status=Status.Pending, AppointmentDateTime=new DateTime(2020,3,17,9,43,00), LengthInHours=2},
                new Appointment{ClientID=4, WorkerID=10, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2020,3,17,9,43,00), LengthInHours=5, TextBox="wordswordswords"},//AI GENERATED from here on
                new Appointment{ClientID=1, WorkerID=8, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,5,9,30,00), LengthInHours=2, TextBox="Appointment 1"},
                new Appointment{ClientID=2, WorkerID=9, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,5,5,12,00,00), LengthInHours=3, TextBox="Appointment 2"},
                new Appointment{ClientID=3, WorkerID=10, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,5,6,10,15,00), LengthInHours=1, TextBox="Appointment 3"},
                new Appointment{ClientID=4, WorkerID=11, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,6,14,45,00), LengthInHours=4, TextBox="Appointment 4"},
                new Appointment{ClientID=5, WorkerID=12, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,7,11,30,00), LengthInHours=2, TextBox="Appointment 5"},
                new Appointment{ClientID=6, WorkerID=8, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,5,7,13,00,00), LengthInHours=3, TextBox="Appointment 6"},
                new Appointment{ClientID=1, WorkerID=9, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,8,10,30,00), LengthInHours=1, TextBox="Appointment 7"},
                new Appointment{ClientID=2, WorkerID=10, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,8,12,45,00), LengthInHours=5, TextBox="Appointment 8"},
                new Appointment{ClientID=3, WorkerID=11, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,9,9,00,00), LengthInHours=3, TextBox="Appointment 9"},
                new Appointment{ClientID=4, WorkerID=12, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,5,10,10,15,00), LengthInHours=2, TextBox="Appointment 10"},
                new Appointment{ClientID=5, WorkerID=8, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,10,14,00,00), LengthInHours=3, TextBox="Appointment 11"},
                new Appointment{ClientID=6, WorkerID=9, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,5,11,9,30,00), LengthInHours=2, TextBox="Appointment 12"},
                new Appointment{ClientID=1, WorkerID=10, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,5,11,12,15,00), LengthInHours=1, TextBox="Appointment 13"},
                new Appointment{ClientID=2, WorkerID=11, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,11,15,45,00), LengthInHours=4, TextBox="Appointment 14"},
                new Appointment{ClientID=3, WorkerID=12, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,11,10,30,00), LengthInHours=2, TextBox="Appointment 15"},
                new Appointment{ClientID=4, WorkerID=8, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,5,11,13,00,00), LengthInHours=3, TextBox="Appointment 16"},
                new Appointment{ClientID=5, WorkerID=9, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,10,10,30,00), LengthInHours=1, TextBox="Appointment 17"},
                new Appointment{ClientID=6, WorkerID=10, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,10,12,45,00), LengthInHours=5, TextBox="Appointment 18"},
                new Appointment{ClientID=1, WorkerID=11, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,11,9,00,00), LengthInHours=3, TextBox="Appointment 19"},
                new Appointment{ClientID=3, WorkerID=8, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,7,14,00,00), LengthInHours=2, TextBox="Appointment 21"},
                new Appointment{ClientID=4, WorkerID=9, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,5,8,9,30,00), LengthInHours=3, TextBox="Appointment 22"},
                new Appointment{ClientID=5, WorkerID=10, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,5,8,12,15,00), LengthInHours=1, TextBox="Appointment 23"},
                new Appointment{ClientID=6, WorkerID=11, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,9,15,45,00), LengthInHours=4, TextBox="Appointment 24"},
                new Appointment{ClientID=1, WorkerID=12, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,10,10,30,00), LengthInHours=2, TextBox="Appointment 25"},
                new Appointment{ClientID=2, WorkerID=8, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,5,11,13,00,00), LengthInHours=3, TextBox="Appointment 26"},
                new Appointment{ClientID=3, WorkerID=9, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,6,10,30,00), LengthInHours=1, TextBox="Appointment 27"},
                new Appointment{ClientID=4, WorkerID=10, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,6,12,45,00), LengthInHours=5, TextBox="Appointment 28"},
                new Appointment{ClientID=5, WorkerID=11, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,7,9,00,00), LengthInHours=3, TextBox="Appointment 29"},
                new Appointment{ClientID=6, WorkerID=12, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,5,8,10,15,00), LengthInHours=2, TextBox="Appointment 30"},
                new Appointment{ClientID=1, WorkerID=8, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,9,14,00,00), LengthInHours=2, TextBox="Appointment 31"},
                new Appointment{ClientID=2, WorkerID=9, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,5,10,9,30,00), LengthInHours=3, TextBox="Appointment 32"},
                new Appointment{ClientID=3, WorkerID=10, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,5,10,12,15,00), LengthInHours=1, TextBox="Appointment 33"},
                new Appointment{ClientID=4, WorkerID=11, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,11,15,45,00), LengthInHours=4, TextBox="Appointment 34"},
                new Appointment{ClientID=5, WorkerID=12, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,11,10,30,00), LengthInHours=2, TextBox="Appointment 35"},
                new Appointment{ClientID=6, WorkerID=8, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,5,11,13,00,00), LengthInHours=3, TextBox="Appointment 36"},
                new Appointment{ClientID=1, WorkerID=9, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,6,10,30,00), LengthInHours=1, TextBox="Appointment 37"},
                new Appointment{ClientID=2, WorkerID=10, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,6,12,45,00), LengthInHours=5, TextBox="Appointment 38"},
                new Appointment{ClientID=3, WorkerID=11, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,7,9,00,00), LengthInHours=3, TextBox="Appointment 39"},
                new Appointment{ClientID=4, WorkerID=12, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,5,8,10,15,00), LengthInHours=2, TextBox="Appointment 40"},
                new Appointment{ClientID=5, WorkerID=8, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,9,14,00,00), LengthInHours=2, TextBox="Appointment 41"},
                new Appointment{ClientID=6, WorkerID=9, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,5,10,9,30,00), LengthInHours=3, TextBox="Appointment 42"},
                new Appointment{ClientID=1, WorkerID=10, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,5,10,12,15,00), LengthInHours=1, TextBox="Appointment 43"},
                new Appointment{ClientID=2, WorkerID=11, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,11,15,45,00), LengthInHours=4, TextBox="Appointment 44"},
                new Appointment{ClientID=3, WorkerID=12, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,11,10,30,00), LengthInHours=2, TextBox="Appointment 45"},
                new Appointment{ClientID=4, WorkerID=8, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,5,11,13,00,00), LengthInHours=3, TextBox="Appointment 46"},
                new Appointment{ClientID=5, WorkerID=9, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,6,10,30,00), LengthInHours=1, TextBox="Appointment 47"},
                new Appointment{ClientID=6, WorkerID=10, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,6,12,45,00), LengthInHours=5, TextBox="Appointment 48"},
                new Appointment{ClientID=2, WorkerID=12, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,5,11,10,15,00), LengthInHours=2, TextBox="Appointment 20"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,5,10,00,00), LengthInHours=2, TextBox="Appointment 49"},
                new Appointment{ClientID=2, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,5,14,00,00), LengthInHours=3, TextBox="Appointment 50"},
                new Appointment{ClientID=3, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,6,10,30,00), LengthInHours=1, TextBox="Appointment 51"},
                new Appointment{ClientID=4, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,6,12,45,00), LengthInHours=5, TextBox="Appointment 52"},
                new Appointment{ClientID=5, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,7,9,00,00), LengthInHours=3, TextBox="Appointment 53"},
                new Appointment{ClientID=6, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,7,14,15,00), LengthInHours=2, TextBox="Appointment 54"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,8,11,30,00), LengthInHours=1, TextBox="Appointment 55"},
                new Appointment{ClientID=2, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,8,13,45,00), LengthInHours=4, TextBox="Appointment 56"},
                new Appointment{ClientID=3, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,9,9,15,00), LengthInHours=2, TextBox="Appointment 57"},
                new Appointment{ClientID=4, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,9,13,30,00), LengthInHours=3, TextBox="Appointment 58"},
                new Appointment{ClientID=5, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,10,10,45,00), LengthInHours=1, TextBox="Appointment 59"},
                new Appointment{ClientID=6, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,10,12,00,00), LengthInHours=2, TextBox="Appointment 60"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,11,10,30,00), LengthInHours=3, TextBox="Appointment 61"},
                new Appointment{ClientID=2, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,11,14,45,00), LengthInHours=2, TextBox="Appointment 62"},
                new Appointment{ClientID=3, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,11,16,15,00), LengthInHours=4, TextBox="Appointment 63"},
                new Appointment{ClientID=4, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,5,12,00,00), LengthInHours=2, TextBox="New Appointment 1"},
                new Appointment{ClientID=5, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,6,15,00,00), LengthInHours=2, TextBox="New Appointment 2"},
                new Appointment{ClientID=6, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,8,14,30,00), LengthInHours=3, TextBox="New Appointment 3"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,10,9,30,00), LengthInHours=2, TextBox="New Appointment 4"}



            };
            appointments.ForEach(s => context.Appointments.Add(s));
            context.SaveChanges();



            var users = new List<User>
            {
                new User{IsActive=true,Username="Admin",Password=BCrypt.Net.BCrypt.HashPassword("Admin")},
                new User{IsActive=true,Username="Username2",Password=BCrypt.Net.BCrypt.HashPassword("Password2")},
                new User{IsActive=true,Username="Username3",Password=BCrypt.Net.BCrypt.HashPassword("Password3")},
                new User{IsActive=true,Username="Username4",Password=BCrypt.Net.BCrypt.HashPassword("Password4")},
                new User{IsActive=true,Username="RoleAdmin",Password=BCrypt.Net.BCrypt.HashPassword("RoleAdmin")},
                new User{IsActive=true,Username="RoleUserControl",Password=BCrypt.Net.BCrypt.HashPassword("RoleUserControl")},
                new User{IsActive=true,Username="RoleAppointmentControl",Password=BCrypt.Net.BCrypt.HashPassword("RoleAppointmentControl")},
                new User{IsActive=true,Username="RoleAppointmentEnd",Password=BCrypt.Net.BCrypt.HashPassword("RoleAppointmentEnd")},
                new User{IsActive=true,Username="RoleClientControl",Password=BCrypt.Net.BCrypt.HashPassword("RoleClientControl")},
                new User{IsActive=true,Username="RoleWorkerControl",Password=BCrypt.Net.BCrypt.HashPassword("RoleWorkerControl")}

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
                new UserRoleMap{UserID=4,RoleID=5},
                new UserRoleMap{UserID=5,RoleID=1},
                new UserRoleMap{UserID=6,RoleID=2},
                new UserRoleMap{UserID=7,RoleID=3},
                new UserRoleMap{UserID=8,RoleID=4},
                new UserRoleMap{UserID=9,RoleID=5},
                new UserRoleMap{UserID=10,RoleID=6}

            };
            userRoleMaps.ForEach(s => context.UserRoleMaps.Add(s));
            context.SaveChanges();
        }
    }
}