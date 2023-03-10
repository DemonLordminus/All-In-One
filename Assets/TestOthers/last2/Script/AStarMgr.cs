using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class AStarMgr : BaseManager<AStarMgr>//A*Ѱ·������ ����ģʽ
//{
//    private int mapW;//��ͼ���
//    private int mapH;

//    private AStarNode[,] nodes;//��ͼ������и��Ӷ�������

//    private List<AStarNode> openList = new List<AStarNode>();//�����б�

//    private List<AStarNode> closeList = new List<AStarNode>();//�ر��б�

//    public void InitMapInfo(int w,int h)//��ʼ����ͼ��Ϣ
//    {
//        this.mapW = w;
//        this.mapH = h;

//        nodes = new AStarNode[w, h];//������������װ���ٸ�����

//        for(int i = 0; i < w; i++)
//        {
//            for(int j = 0; j < h; j++)
//            {
//                AStarNode node = new AStarNode(i, j, Random.Range(0, 100) < 20 ? E_Node_Type.Stop : E_Node_Type.Walk);
//                nodes[i,j] = node;
//            }
//        }
//    }

//    public List<AStarNode>FindPath(Vector2 startPos,Vector2 endPos)//Ѱ·����
//    {
//        //�ڵ�ͼ��Χ��
//        if(startPos.x < 0 || startPos.x >= mapW || startPos.y < 0 || startPos.y >= mapH||
//            endPos.x < 0 || endPos.x >= mapW || endPos.y < 0 || endPos.y >= mapH)
//        {
//            return null;
//        }

//        //�����赲
//        AStarNode start = nodes[(int)startPos.x, (int)startPos.y];
//        AStarNode end = nodes[(int)endPos.x, (int)endPos.y];
//        if (start.type == E_Node_Type.Stop || end.type == E_Node_Type.Stop)
//        {
//            return null;
//        }

//        //�����һ����ص�����

//        //��տ�ʼ�͹ر��б�
//        closeList.Clear();
//        openList.Clear();

//        //�ѿ�ʼ�����ر��б���
//        start.father = null;
//        start.f = 0;
//        start.g = 0;
//        start.h = 0;
//        closeList.Add(start);

//       while(true)
//       {
//            //����㿪ʼ������Χ�ĵ㲢���뿪���б���
//            FindNearlyNodeToOpenLIst(start.x - 1, start.y - 1, 1.4f, start, end);
//            FindNearlyNodeToOpenLIst(start.x, start.y - 1, 1, start, end);
//            FindNearlyNodeToOpenLIst(start.x + 1, start.y - 1, 1.4f, start, end);
//            FindNearlyNodeToOpenLIst(start.x - 1, start.y, 1, start, end);
//            FindNearlyNodeToOpenLIst(start.x + 1, start.y, 1, start, end);
//            FindNearlyNodeToOpenLIst(start.x - 1, start.y + 1, 1.4f, start, end);
//            FindNearlyNodeToOpenLIst(start.x, start.y + 1, 1, start, end);
//            FindNearlyNodeToOpenLIst(start.x + 1, start.y + 1, 1.4f, start, end);

//            //��·�ж�
//            if(openList.Count == 0)
//            {
//                return null;
//            }

//            //ѡ�������б���Ѱ·������С�ĵ�
//            openList.Sort(SortOpenList);

//            //����ر��б��У��ٴӿ����б����Ƴ�
//            closeList.Add(openList[0]);

//            //�ҵ�����㣬�ֱ���µ���㣬������һ��Ѱ·����
//            start = openList[0];
//            openList.RemoveAt(0);
//            if (start == end)
//            {
//                //������ �ҵ�·����
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

//    private void FindNearlyNodeToOpenLIst(int x, int y, float g, AStarNode father, AStarNode end)//���ٽ��ĵ���뿪���б���
//    {
//        //�߽��ж�
//        if (x < 0 || x >= mapW || y < 0 || y >= mapH)
//        {
//            return;
//        }

//        AStarNode node = nodes[x, y];
//        //�ж��Ƿ��Ǳ߽磬�赲���Ƿ��ڿ����б��ر��б������ǲŷ��뿪���б���
//        if (node == null || node.type == E_Node_Type.Stop || closeList.Contains(node) || openList.Contains(node))
//        {
//            return;
//        }

//        //����fֵ
//        //��¼������
//        node.father = father;
//        node.g = father.g + g;
//        node.h = Mathf.Abs(end.x - node.x) + Mathf.Abs(end.y - node.y);

//        //���ͨ��������ĺϷ���֤���ͷ��뿪���б���
//        openList.Add(node);
//    }
//}
