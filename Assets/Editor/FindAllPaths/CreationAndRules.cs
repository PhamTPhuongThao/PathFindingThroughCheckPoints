using UnityEngine;

public class CreationAndRules
{
   public class Node
   {
      public Vector2 position;
      public float[] canVisitX;
      public float[] canVisitY;
      public Node[] nextNodesATB;
      public Node[] nextNodesBTA;
   }

   public class RootNode
   {
      public int numberOfTeam;
      public Node[] Team;
   }
   public RootNode ATeam;
   public RootNode BTeam;

   private void RulesFromRootToOther(RootNode team, RootNode otherteam)
   {
      for (int i = 0; i < team.numberOfTeam; i++)
      {
         if (team.Team[i].position.x < 3)
         {
            // middle node
            if ((team.Team[i].position.y + 1 < 2) && (team.Team[i].position.y - 1 > -2))
            {
               if (team.Team[i].position.x == 1)
               {
                  var xCanVisit = new float[2] { team.Team[i].position.x + 1, team.Team[i].position.x };
                  team.Team[i].canVisitX = xCanVisit;
               }
               else
               {
                  var xCanVisit = new float[1] { team.Team[i].position.x + 1 };
                  team.Team[i].canVisitX = xCanVisit;
               }
               var yCanVisit = new float[3] { team.Team[i].position.y + 1, team.Team[i].position.y, team.Team[i].position.y - 1 };
               team.Team[i].canVisitY = yCanVisit;
            }

            // upper node
            if (team.Team[i].position.y + 1 == 2)
            {
               if (team.Team[i].position.x == 1)
               {
                  var xCanVisit = new float[2] { team.Team[i].position.x + 1, team.Team[i].position.x };
                  team.Team[i].canVisitX = xCanVisit;
               }
               else
               {
                  var xCanVisit = new float[1] { team.Team[i].position.x + 1 };
                  team.Team[i].canVisitX = xCanVisit;
               }

               var yCanVisit = new float[2] { team.Team[i].position.y, team.Team[i].position.y - 1 };

               team.Team[i].canVisitY = yCanVisit;
            }

            // lower node
            if (team.Team[i].position.y - 1 == -2)
            {
               if (team.Team[i].position.x == 1)
               {
                  var xCanVisit = new float[2] { team.Team[i].position.x + 1, team.Team[i].position.x };
                  team.Team[i].canVisitX = xCanVisit;
               }
               else
               {
                  var xCanVisit = new float[1] { team.Team[i].position.x + 1 };
                  team.Team[i].canVisitX = xCanVisit;
               }
               var yCanVisit = new float[2] { team.Team[i].position.y + 1, team.Team[i].position.y };
               team.Team[i].canVisitY = yCanVisit;
            }
         }

         else
         {
            // last column of team to other team
            var xCanVisit = new float[1] { team.Team[i].position.x };
            team.Team[i].canVisitX = xCanVisit;

            // middle node
            if ((team.Team[i].position.y + 1 < 2) && (team.Team[i].position.y - 1 > -2))
            {
               var yCanVisit = new float[3] { team.Team[i].position.y + 1, team.Team[i].position.y, team.Team[i].position.y - 1 };
               team.Team[i].canVisitY = yCanVisit;
            }

            // upper node
            if (team.Team[i].position.y + 1 == 2)
            {
               var yCanVisit = new float[2] { team.Team[i].position.y, team.Team[i].position.y - 1 };
               team.Team[i].canVisitY = yCanVisit;
            }

            // lower node
            if (team.Team[i].position.y - 1 == -2)
            {
               var yCanVisit = new float[2] { team.Team[i].position.y + 1, team.Team[i].position.y };
               team.Team[i].canVisitY = yCanVisit;
            }
         }

      }
      for (int i = 0; i < otherteam.numberOfTeam; i++)
      {
         if (otherteam.Team[i].position.x > 1)
         {
            // middle node
            if ((otherteam.Team[i].position.y + 1 < 2) && (otherteam.Team[i].position.y - 1 > -2))
            {
               var xCanVisit = new float[1] { otherteam.Team[i].position.x - 1 };
               otherteam.Team[i].canVisitX = xCanVisit;
               var yCanVisit = new float[3] { otherteam.Team[i].position.y + 1, otherteam.Team[i].position.y, otherteam.Team[i].position.y - 1 };
               otherteam.Team[i].canVisitY = yCanVisit;
            }

            // upper node
            if (otherteam.Team[i].position.y + 1 == 2)
            {
               var xCanVisit = new float[1] { otherteam.Team[i].position.x - 1 };
               var yCanVisit = new float[2] { otherteam.Team[i].position.y, otherteam.Team[i].position.y - 1 };
               otherteam.Team[i].canVisitX = xCanVisit;
               otherteam.Team[i].canVisitY = yCanVisit;
            }

            // lower node
            if (otherteam.Team[i].position.y - 1 == -2)
            {
               var xCanVisit = new float[1] { otherteam.Team[i].position.x - 1 };
               var yCanVisit = new float[2] { otherteam.Team[i].position.y + 1, otherteam.Team[i].position.y };
               otherteam.Team[i].canVisitX = xCanVisit;
               otherteam.Team[i].canVisitY = yCanVisit;
            }
         }
         else if (otherteam.Team[i].position.x == 1)
         {
            var xCanVisit = new float[2] { otherteam.Team[i].position.x, otherteam.Team[i].position.x - 1 };
            otherteam.Team[i].canVisitX = xCanVisit;

            // middle node
            if ((otherteam.Team[i].position.y + 1 < 2) && (otherteam.Team[i].position.y - 1 > -2))
            {
               var yCanVisit = new float[2] { otherteam.Team[i].position.y, otherteam.Team[i].position.y - 1 };
               otherteam.Team[i].canVisitY = yCanVisit;
            }

            // upper node
            if (otherteam.Team[i].position.y + 1 == 2)
            {
               var yCanVisit = new float[1] { otherteam.Team[i].position.y - 1 };
               otherteam.Team[i].canVisitY = yCanVisit;
            }

            // lower node
            if (otherteam.Team[i].position.y - 1 == -2)
            {
               var yCanVisit = new float[1] { otherteam.Team[i].position.y + 1 };
               otherteam.Team[i].canVisitY = yCanVisit;
            }

         }
         else if (otherteam.Team[i].position.x == 0)
         {
            otherteam.Team[i].canVisitX = null;
            otherteam.Team[i].canVisitY = null;
         }
      }
   }

   private void CreateTeam(RootNode team)
   {
      team.numberOfTeam = 10;
      team.Team = new Node[team.numberOfTeam];
      for (int i = 0; i < team.numberOfTeam; i++)
      {
         team.Team[i] = new Node();
         switch (i)
         {
            case 0:
               team.Team[i].position = Vector2.zero;
               break;
            case 1:
               team.Team[i].position = Vector2.one;
               break;
            case 2:
               team.Team[i].position.x = 1;
               team.Team[i].position.y = 0;
               break;
            case 3:
               team.Team[i].position.x = 1;
               team.Team[i].position.y = -1;
               break;
            case 4:
               team.Team[i].position.x = 2;
               team.Team[i].position.y = 1;
               break;
            case 5:
               team.Team[i].position.x = 2;
               team.Team[i].position.y = 0;
               break;
            case 6:
               team.Team[i].position.x = 2;
               team.Team[i].position.y = -1;
               break;
            case 7:
               team.Team[i].position.x = 3;
               team.Team[i].position.y = 1;
               break;
            case 8:
               team.Team[i].position.x = 3;
               team.Team[i].position.y = 0;
               break;
            case 9:
               team.Team[i].position.x = 3;
               team.Team[i].position.y = -1;
               break;
         }
      }
   }

   public void CreateBothTeam()
   {
      ATeam = new RootNode();
      BTeam = new RootNode();
      CreateTeam(ATeam);
      CreateTeam(BTeam);
      RulesFromRootToOther(ATeam, BTeam);
   }

}
