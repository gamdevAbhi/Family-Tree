using System.Numerics;

namespace FamilyTree;

public partial class FamilyTree : Form
{
    private readonly Pen linePen = new Pen(Color.Black, 2);
    private readonly Brush offspringBrush = Brushes.Blue;
    private readonly Brush spouseBrush = Brushes.Red;
    private readonly Font font;
    private readonly int fontSize = 10;
    private readonly int xOffset = 50;
    private readonly int yOffset = 50;
    private readonly Panel drawingPanel;
    private readonly Tree tree;

    private readonly Dictionary<Person, Vector2> points = new Dictionary<Person, Vector2>();

    public FamilyTree(Tree tree, float scale = 1)
    {
        fontSize = (int)(fontSize * scale);
        xOffset = (int)(xOffset * scale);
        yOffset = (int)(yOffset * scale);

        font = new Font("Monaspace Neon Frozen", fontSize);

        drawingPanel = new Panel
        {
            AutoScroll = true,
            Dock = DockStyle.Fill
        };

        this.tree = tree;

        CalculateTree(tree, -1, 50, 50);
        SetPanelSize();
        InitializeComponent();
    }

    private void SetPanelSize()
    {
        if (points.Count == 0) return;

        float minX = points.Values.Min(p => p.X);
        float maxX = points.Values.Max(p => p.X);
        float minY = points.Values.Min(p => p.Y);
        float maxY = points.Values.Max(p => p.Y);

        int padding = 50;
        int maxNameLength = points.Keys.Max(p => p.name.Length);
        int width = (int)(maxX - minX + (maxNameLength + 1) * fontSize + 2 * padding);
        int height = (int)(maxY - minY + fontSize + 2 * padding);

        drawingPanel.AutoScrollMinSize = new Size(width, height);
        
        drawingPanel.AutoScrollPosition = new Point(
            Math.Max(0, (width - ClientSize.Width) / 2),
            Math.Max(0, (height - ClientSize.Height) / 2)
        );
    }

    public void DrawPedigree(object sender, PaintEventArgs paint)
    {
        paint.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        paint.Graphics.TranslateTransform(drawingPanel.AutoScrollPosition.X, drawingPanel.AutoScrollPosition.Y);
        DrawTree(tree, paint);
    }

    public int CalculateTree(Tree tree, int index, int x, int height)
    {
        int left = tree.childTrees.Count / 2;

        for (int i = 0; i < left; i++) x = CalculateTree(tree.childTrees[i], i, x, height + yOffset);

        if (index > 0)
        {
            x = AddPerson(tree.offspring, x, height);
            x = AddPerson(tree.spouse, x, height);
        }
        else
        {
            x = AddPerson(tree.spouse, x, height);
            x = AddPerson(tree.offspring, x, height);
        }

        for (int i = left; i < tree.childTrees.Count; i++) x = CalculateTree(tree.childTrees[i], i, x, height + yOffset);

        return x;
    }

    private void DrawTree(Tree tree, PaintEventArgs paint)
    {
        DrawCouple(tree, paint);
        DrawConnection(tree, paint);

        foreach (Tree childTree in tree.childTrees) DrawTree(childTree, paint);
    }

    public int AddPerson(Person? person, int x, int height)
    {
        if (person == null || points.ContainsKey(person)) return x;

        points.Add(person, new Vector2(x, height));

        return GetOffset(x, person.name.Length);
    }

    public void DrawCouple(Tree tree, PaintEventArgs paint)
    {
        if (tree.offspring != null) paint.Graphics.DrawString(tree.offspring.name, font, offspringBrush,
        points[tree.offspring].X, points[tree.offspring].Y);

        if (tree.spouse != null) paint.Graphics.DrawString(tree.spouse.name, font, spouseBrush,
        points[tree.spouse].X, points[tree.spouse].Y);
    }

    public void DrawConnection(Tree tree, PaintEventArgs paint)
    {
        if (tree.spouse == null) return;

        int x1, y1, x2, y2, midX, midY;

        (x1, y1, x2, y2) = CalculateLinePoints(tree);
        (midX, midY) = CalculateMidPoint(x1, y1, x2, y2);

        paint.Graphics.DrawLine(linePen, x1, y1, x2, y2);

        if (tree.childTrees.Count == 0) return;

        int y = midY + (yOffset / 2);

        paint.Graphics.DrawLine(linePen, midX, midY, midX, y);

        Tree leftChildTree = tree.childTrees[0], rightChildTree = tree.childTrees[^1];

        int leftMidX, rightMidX;

        if (leftChildTree != rightChildTree)
        {
            (leftMidX, _) = CalculateOffspringMidPoint(leftChildTree);
            (rightMidX, _) = CalculateOffspringMidPoint(rightChildTree);
        }
        else
        {
            leftMidX = midX;
            (rightMidX, _) = CalculateOffspringMidPoint(rightChildTree);
        }

        paint.Graphics.DrawLine(linePen, leftMidX, y, rightMidX, y);

        foreach (Tree childTree in tree.childTrees)
        {
            int childX, childY;

            (childX, childY) = CalculateOffspringMidPoint(childTree);

            paint.Graphics.DrawLine(linePen, childX, y, childX, childY);
        }

    }

    private (int, int, int, int) CalculateLinePoints(Tree tree)
    {
        if (tree.spouse == null)
        {
            int childMidX = (tree.offspring.name.Length + 1) * fontSize;

            return ((int)points[tree.offspring].X, (int)points[tree.offspring].Y,
            (int)points[tree.offspring].X + childMidX, (int)points[tree.offspring].Y);
        }

        int leftX = (int)Math.Min(points[tree.offspring].X, points[tree.spouse].X);
        int rightX = (int)Math.Max(points[tree.offspring].X, points[tree.spouse].X);

        int length;

        if (leftX == points[tree.offspring].X) length = tree.offspring.name.Length;
        else length = tree.spouse.name.Length;

        int x1 = GetPointOffset(leftX, length);
        int x2 = rightX;

        int y1 = (int)points[tree.spouse].Y + fontSize;
        int y2 = (int)points[tree.offspring].Y + fontSize;

        return (x1, y1, x2, y2);
    }

    private (int, int) CalculateOffspringMidPoint(Tree tree)
    {
        int childMidX = (tree.offspring.name.Length + 1) * fontSize;
        int x1, x2, y1, y2;

        (x1, y1, x2, y2) = ((int)points[tree.offspring].X, (int)points[tree.offspring].Y,
        (int)points[tree.offspring].X + childMidX, (int)points[tree.offspring].Y);

        return ((x1 + x2) / 2, (y1 + y2) / 2);
    }
    private static (int, int) CalculateMidPoint(int x1, int y1, int x2, int y2)
    {
        return ((x1 + x2) / 2, (y1 + y2) / 2);
    }

    private static (int, int) CalculateMidPoint((int, int, int, int) value)
    {
        return CalculateMidPoint(value.Item1, value.Item2, value.Item3, value.Item4);
    }

    private int GetOffset(int x, int length)
    {
        return x + ((length + 1) * fontSize) + xOffset;
    }

    private int GetPointOffset(int x, int length)
    {
        return x + ((length + 1) * fontSize);
    }
}