using Ass14.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ass14.Controllers
{
    public class PlayersController : Controller
    {
        string conString = ConfigurationManager.ConnectionStrings["Players"].ConnectionString;
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader srdr;

        // GET: Players
        public ActionResult Index()
        {
            List<Player> players = new List<Player>();

            try
            {

                con = new SqlConnection(conString);
                cmd = new SqlCommand("Select * from Players");
                cmd.Connection = con;
                con.Open();
                srdr = cmd.ExecuteReader();
                while (srdr.Read())
                {
                    players.Add(
                        new Player
                        {
                            PId = (int)(srdr["PId"]),
                            FName = (string)srdr["FName"],
                            LName = (string)(srdr["LName"]),
                            JerseyNumber = (int)(srdr["JerseyNumber"]),
                            Position = (string)(srdr["Position"]),
                            Team = (string)(srdr["Team"])
                        }
                        );
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
            finally { con.Close(); }

            return View(players);
        }

        // GET: Players/Details/5
        public ActionResult Details(int PId)
        {
            return View();
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            return View(new Player());
        }

        // POST: Players/Create
        [HttpPost]
        public ActionResult Create(Player player)
        {
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("insert into Player values(@PId,@FName,@LName,@JerseyNumber,@Position,@Team)");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@PId", player.PId);
                cmd.Parameters.AddWithValue("@FName", player.FName);
                cmd.Parameters.AddWithValue("@LName", player.LName);
                cmd.Parameters.AddWithValue("@JerseyNumber", player.JerseyNumber);
                cmd.Parameters.AddWithValue("@Position", player.Position);
                cmd.Parameters.AddWithValue("@Team", player.Team);

                con.Open();
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
            finally { con.Close(); }
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int PId)
        {
            return View();
        }

        // POST: Players/Edit/5
        [HttpPost]
        public ActionResult Edit(int PId, Player players)
        {
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("update Player set FName=@FName,LName=@LName,JerseyNumber=@JerseyNumber,Position=@Position,Team=@Team where PId=@PId");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@PId", players.PId);
                cmd.Parameters.AddWithValue("@FName", players.FName);
                cmd.Parameters.AddWithValue("@LName", players.LName);
                cmd.Parameters.AddWithValue("@JerseyNumber", players.JerseyNumber);
                cmd.Parameters.AddWithValue("@Position", players.Position);
                cmd.Parameters.AddWithValue("@Team", players.Team);

                con.Open();
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
            finally { con.Close(); }
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int PId)
        {

            return View();
        }

        // POST: Players/Delete/5
        [HttpPost]
        public ActionResult Delete(int PId, Player player)
        {
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("delete from Player where PId=@PId");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@PId", player.PId);

                con.Open();
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
            finally { con.Close(); }
        }

        // GET: Player
    }
}