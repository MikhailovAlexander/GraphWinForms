using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphWinForms
{
    public class TreePointsDSU
    {
        private int id;
        private int root;
        private List<TreePointsDSU> branches;
        public int Id => id;
        public int Root => root;
        public bool IsLeaf => branches.Count == 0;
        public Point Point { get; set; }
        public bool IsEmpty => Point == Point.Empty;
        public int Levels => LevelCounter(0);
        public int BranchesCount => branches.Count;
        public IReadOnlyCollection<TreePointsDSU> BranchesReadOnly => branches;

        public TreePointsDSU(int id, int root)
        {
            this.id = id;
            this.root = root;
            branches = new List<TreePointsDSU>();
            Point = Point.Empty;
        }

        public static List<TreePointsDSU> GetTrees(IValiableDSU dsu, Point firstPoint, int size, int interval)
        {
            firstPoint.Offset(size / 2, size / 2);
            List<TreePointsDSU> trees = new List<TreePointsDSU>();
            TreePointsDSU currentTree;
            for (int i = 0; i < dsu.GetCount(); i++)
            {
                if (dsu.GetValue(i) == i)
                {
                    currentTree = new TreePointsDSU(i, i);
                    trees.Add(currentTree);
                    FindAllBranches(currentTree);
                }
            }
            ListSetPoints(trees, firstPoint, size, interval);
            return trees;
            void FindAllBranches(TreePointsDSU tree)
            {
                TreePointsDSU addedTree;
                for (int i = 0; i < dsu.GetCount(); i++)
                {
                    if (dsu.GetValue(i) == tree.id && i != tree.id)
                    {
                        addedTree = new TreePointsDSU(i, tree.root);
                        tree.branches.Add(addedTree);
                        FindAllBranches(addedTree);
                    }
                }
            }
        }

        private static void ListSetPoints(List<TreePointsDSU> list, Point firstPoint, int size, int interval)
        {
            int X = firstPoint.X;
            foreach (var tree in list)
                X = tree.SetPoints(X, firstPoint.Y, size, interval);
        }

        public int SetPoints(int X, int Y, int size, int interval)
        {
            int leftBound = X;
            if (this.IsLeaf)
            {
                Point = new Point(X + size / 2, Y);
                return X + size + interval;
            }
            foreach (var branch in this.branches)
            {
                X = branch.SetPoints(X, Y + size + interval, size, interval);
            }
            this.Point = new Point((leftBound + X) / 2, Y);
            return X;
        }

        private int LevelCounter(int level)
        {
            if (this.IsLeaf) return level++;
            int levelCnt = level + 1;
            foreach (var tree in this.branches)
                levelCnt = Max(levelCnt, tree.LevelCounter(level + 1));
            return levelCnt;
        }

        int Max(int a, int b)
        {
            if (a > b) return a;
            return b;
        }
    }

}
