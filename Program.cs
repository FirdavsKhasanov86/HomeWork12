﻿using System;
using System.Data.SqlClient;
using System.Data;

namespace HomeWork12
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("CHOISE YOUR NUMBER:");
            Console.WriteLine("1.SELECT ALL FROM DB Person");
            Console.WriteLine("2.INSERT INTO DB Person");
            Console.WriteLine("3.SelectBy ID in DB Person");
            Console.WriteLine("4.Update infomation clients from DB Person");
            Console.WriteLine("5.Delete user from DB Person");
            string choise = Console.ReadLine();
            if (choise == "1")
            {
                selectAll();
            }

            if (choise == "2")
            {
                Console.Write("Write name of Person:");
                string Name = Console.ReadLine();
                Console.Write("Write surename of Person:");
                string SureName = Console.ReadLine();
                Console.Write("Write middlename of Person:");
                string MiddleName = Console.ReadLine();
                Insert(Name, SureName, MiddleName);
            }

            if (choise == "3")
            {
               Console.Write("Write id for DB Person:");
               int num = int.Parse(Console.ReadLine());
               SelectBy(num);
            }

            if(choise == "4"){
                Console.Write("Write name of Person:");
                string Name = Console.ReadLine();
                Console.Write("Write surename of Person:");
                string SureName = Console.ReadLine();
                Console.Write("Write middlename of Person:");
                string MiddleName = Console.ReadLine();
              Update(Name, SureName, MiddleName);
            }

            if(choise == "5"){
               Console.Write("Write id for DELETE client from DB Person:");
               int num = int.Parse(Console.ReadLine());
                Delete(num);
            }



            //selectAll
            static void selectAll()
            {
                string conString = @"Data source=192.168.103.131; Initial catalog=testdb; user id=sa; password=Sa123.";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string commandText = "Select * from Person";
                SqlCommand command = new SqlCommand(commandText, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    System.Console.WriteLine($"ID:{reader.GetValue(0)}, FirstName:{reader.GetValue(1)}, LastName:{reader.GetValue(2)}, MiddleName:{reader.GetValue(3)},BirthDate:{reader.GetValue(4)}");
                }
                reader.Close();
            }

            //insert
            static void Insert(string Name, string SureName, string MiddleName)
            {
                string conString = @"Data source=192.168.103.131; Initial catalog=testdb; user id=sa; password=Sa123.";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                //string date=$"{DateTime.Now.Year}-{DateTime.Now.Day}-{DateTime.Now.Month}";
                string date = DateTime.Now.ToString("yyyy-mm-dd");

                string insertSqlCommand = string.Format($"insert into Person([FirstName],[LastName],[MiddleName],[BirthDate]) Values('{Name}', '{SureName}','{MiddleName}',{date}) ");
                SqlCommand command = new SqlCommand(insertSqlCommand, con);
                command = new SqlCommand(insertSqlCommand, con);
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    System.Console.WriteLine("Insert command successfull!!!");
                }
                con.Close();
            }




            //selectById
            static void SelectBy(int num)
            {
                string conString = @"Data source=192.168.103.131; Initial catalog=testdb; user id=sa; password=Sa123.";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string commandText1 = ($"Select * from Person where id = {num}");
                SqlCommand command = new SqlCommand(commandText1, con);
                SqlDataReader reader1 = command.ExecuteReader();
                while (reader1.Read())
                {
                    System.Console.WriteLine($"ID:{reader1.GetValue(0)}, FirstName:{reader1.GetValue(1)}, LastName:{reader1.GetValue(2)}, MiddleName:{reader1.GetValue(3)},BirthDate:{reader1.GetValue(4)}");
                }
                reader1.Close();
            }


            //Update
            static void Update(string Name, string SureName, string MiddleName){
                string conString = @"Data source=192.168.103.131; Initial catalog=testdb; user id=sa; password=Sa123.";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string date = DateTime.Now.ToString("yyyy-mm-dd");
                string commandText1 = ($"Update Person set FirstName='{Name}',LastName='{SureName}',MiddleName='{MiddleName}',BirthDate={date}");
                SqlCommand command = new SqlCommand(commandText1, con);
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                  System.Console.WriteLine("Updated!!");
                }
                con.Close(); 
            }
            

            //Delete
            static void Delete(int num){
                string conString = @"Data source=192.168.103.131; Initial catalog=testdb; user id=sa; password=Sa123.";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                 string commandText1 = ($"Delete from Person where id = {num}");
                 SqlCommand command = new SqlCommand(commandText1, con);

                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                  System.Console.WriteLine("DELETED!!");
                }
                con.Close(); 
            }
           





        }
    }
}

