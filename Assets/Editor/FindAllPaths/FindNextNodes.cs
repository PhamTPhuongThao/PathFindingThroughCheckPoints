using UnityEngine;

public class FindNextNodes
{
   CreationAndRules creationAndRules;
   public FindNextNodes()
   {
      creationAndRules = new CreationAndRules();
      creationAndRules.CreateBothTeam();
   }
   public void FindingNextNodes()
   {
      for (var i = 0; i < creationAndRules.ATeam.numberOfTeam; i++)
      {
         FindNextNodeOfNodeFromAToB(creationAndRules.ATeam.Team[i]);
      }
      for (var i = 0; i < creationAndRules.BTeam.numberOfTeam; i++)
      {
         FindNextNodeOfNodeFromAToB(creationAndRules.BTeam.Team[i]);
      }
      FindNextNodeOfNodeFromBToA();
      //   for (var index = 0; index < creationAndRules.BTeam.Team[2].nextNodesBTA.Length; index++)
      //   {
      //      Debug.Log(creationAndRules.BTeam.Team[2].nextNodesBTA[index].position);
      //   }
      //Debug.Log(creationAndRules.ATeam.Team[2].nextNodesATB.Length);
   }

   private void FindNextNodeOfNodeFromAToB(CreationAndRules.Node node)
   {
      if (node.canVisitY == null || node.canVisitX == null)
      {
         return;
      }
      var numberOfNodeCanVisit = 0;
      for (var ix = 0; ix < node.canVisitX.Length; ix++)
      {
         for (var iy = 0; iy < node.canVisitY.Length; iy++)
         {
            if (node.position.x == node.canVisitX[ix] && node.position.y == node.canVisitY[iy])
            {
            }
            else
            {
               numberOfNodeCanVisit++;
            }
         }
      }
      node.nextNodesATB = new CreationAndRules.Node[numberOfNodeCanVisit];
      var count = 0;
      for (var ix = 0; ix < node.canVisitX.Length; ix++)
      {
         for (var iy = 0; iy < node.canVisitY.Length; iy++)
         {
            if (node.position.x == node.canVisitX[ix] && node.position.y == node.canVisitY[iy])
            {
            }
            else
            {
               node.nextNodesATB[count] = new CreationAndRules.Node();
               node.nextNodesATB[count].position = new Vector2(node.canVisitX[ix], node.canVisitY[iy]);
               count++;
            }
         }
      }
   }

   private void FindNextNodeOfNodeFromBToA()
   {
      for (var index = 0; index < creationAndRules.ATeam.numberOfTeam; index++)
      {
         creationAndRules.ATeam.Team[index].nextNodesBTA = creationAndRules.BTeam.Team[index].nextNodesATB;
         creationAndRules.BTeam.Team[index].nextNodesBTA = creationAndRules.ATeam.Team[index].nextNodesATB;
      }
   }
}
