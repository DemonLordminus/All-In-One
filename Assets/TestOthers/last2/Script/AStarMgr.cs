using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class AStarMgr : BaseManager<AStarMgr>//A*寻路管理器 单例模式
//{
//    private int mapW;//地图相关
//    private int mapH;

//    private AStarNode[,] nodes;//地图相关所有格子对象容器

//    private List<AStarNode> openList = new List<AStarNode>();//开启列表

//    private List<AStarNode> closeList = new List<AStarNode>();//关闭列表

//    public void InitMapInfo(int w,int h)//初始化地图信息
//    {
//        this.mapW = w;
//        this.mapH = h;

//        nodes = new AStarNode[w, h];//声明容器可以装多少个格子

//        for(int i = 0; i < w; i++)
//        {
//            for(int j = 0; j < h; j++)
//            {
//                AStarNode node = new AStarNode(i, j, Random.Range(0, 100) < 20 ? E_Node_Type.Stop : E_Node_Type.Walk);
//                nodes[i,j] = node;
//            }
//        }
//    }

//    public List<AStarNode>FindPath(Vector2 startPos,Vector2 endPos)//寻路方法
//    {
//        //在地图范围内
//        if(startPos.x < 0 || startPos.x >= mapW || startPos.y < 0 || startPos.y >= mapH||
//            endPos.x < 0 || endPos.x >= mapW || endPos.y < 0 || endPos.y >= mapH)
//        {
//            return null;
//        }

//        //不是阻挡
//        AStarNode start = nodes[(int)startPos.x, (int)startPos.y];
//        AStarNode end = nodes[(int)endPos.x, (int)endPos.y];
//        if (start.type == E_Node_Type.Stop || end.type == E_Node_Type.Stop)
//        {
//            return null;
//        }

//        //清空上一次相关的数据

//        //清空开始和关闭列表
//        closeList.Clear();
//        openList.Clear();

//        //把开始点放入关闭列表中
//        start.father = null;
//        start.f = 0;
//        start.g = 0;
//        start.h = 0;
//        closeList.Add(start);

//       while(true)
//       {
//            //从起点开始，找周围的点并放入开启列表中
//            FindNearlyNodeToOpenLIst(start.x - 1, start.y - 1, 1.4f, start, end);
//            FindNearlyNodeToOpenLIst(start.x, start.y - 1, 1, start, end);
//            FindNearlyNodeToOpenLIst(start.x + 1, start.y - 1, 1.4f, start, end);
//            FindNearlyNodeToOpenLIst(start.x - 1, start.y, 1, start, end);
//            FindNearlyNodeToOpenLIst(start.x + 1, start.y, 1, start, end);
//            FindNearlyNodeToOpenLIst(start.x - 1, start.y + 1, 1.4f, start, end);
//            FindNearlyNodeToOpenLIst(start.x, start.y + 1, 1, start, end);
//            FindNearlyNodeToOpenLIst(start.x + 1, start.y + 1, 1.4f, start, end);

//            //死路判断
//            if(openList.Count == 0)
//            {
//                return null;
//            }

//            //选出开启列表中寻路消耗最小的点
//            openList.Sort(SortOpenList);

//            //放入关闭列表中，再从开启列表中移除
//            closeList.Add(openList[0]);

//            //找得这个点，又变成新的起点，进行下一次寻路计算
//            start = openList[0];
//            openList.RemoveAt(0);
//            if (start == end)
//            {
//                //找完了 找到路径了
//                List<AStarNode> path = new List<AStarNode>();
//                path.Add(end);
//                while(end.father != null)
//                {
//                    path.Add(end.father);
//                    end = end.father;
//                }
//                path.Reverse();
//                return path;
//            }
//       }
//    }

//    private int SortOpenList(AStarNode a,AStarNode b)
//    {
//        if(a.f > b.f)
//        {
//            return 1;
//        }
//        else
//        {
//            return -1;
//        }
//    }

//    private void FindNearlyNodeToOpenLIst(int x, int y, float g, AStarNode father, AStarNode end)//把临近的点放入开启列表中
//    {
//        //边界判断
//        if (x < 0 || x >= mapW || y < 0 || y >= mapH)
//        {
//            return;
//        }

//        AStarNode node = nodes[x, y];
//        //判断是否是边界，阻挡，是否在开启列表，关闭列表，都不是才放入开启列表中
//        if (node == null || node.type == E_Node_Type.Stop || closeList.Contains(node) || openList.Contains(node))
//        {
//            return;
//        }

//        //计算f值
//        //记录父对象
//        node.father = father;
//        node.g = father.g + g;
//        node.h = Mathf.Abs(end.x - node.x) + Mathf.Abs(end.y - node.y);

//        //如果通过了上面的合法验证，就放入开启列表中
//        openList.Add(node);
//    }
//}
