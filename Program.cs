var solution = new Solution();

var rectangles = new List<(int x, int y, int width, int height)> {
            (1, 4, 3, 3),  // R1: (1,4) to (4,1)
            (-1, 3, 2, 1), // R2: (-1,3) to (1,2)
            (0, 5, 4, 3)   // R3: (0,5) to (4,2)
        };

Console.WriteLine(solution.DoRectanglesOverlap(rectangles)); // Output: True

// Additional test case: No overlap
var noOverlap = new List<(int x, int y, int width, int height)> {
            (1, 4, 1, 1),  // (1,4) to (2,3)
            (3, 2, 1, 1)   // (3,2) to (4,1)
        };

Console.WriteLine(solution.DoRectanglesOverlap(noOverlap)); // Output: False

public class Rectangle
{
    public int X1 { get; set; } // Top-left x
    public int Y1 { get; set; } // Top-left y
    public int X2 { get; set; } // Bottom-right x
    public int Y2 { get; set; } // Bottom-right y

    public Rectangle(int x, int y, int width, int height)
    {
        X1 = x;
        Y1 = y;
        X2 = x + width;
        Y2 = y - height; // y decreases as we go down
    }
}

public class Solution
{
    public bool DoRectanglesOverlap(List<(int x, int y, int width, int height)> rectangles)
    {
        // Convert input to Rectangle objects
        var rects = new List<Rectangle>();
        foreach (var rect in rectangles)
        {
            rects.Add(new Rectangle(rect.x, rect.y, rect.width, rect.height));
        }

        // Check all pairs for overlap
        for (int i = 0; i < rects.Count; i++)
        {
            for (int j = i + 1; j < rects.Count; j++)
            {
                if (Overlap(rects[i], rects[j]))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool Overlap(Rectangle r1, Rectangle r2)
    {
        // Check if one rectangle is to the left or right of the other
        if (r1.X1 > r2.X2 || r2.X1 > r1.X2)
        {
            return false;
        }
        // Check if one rectangle is above or below the other
        if (r1.Y1 < r2.Y2 || r2.Y1 < r1.Y2)
        {
            return false;
        }
        // If neither condition holds, the rectangles overlap
        return true;
    }
}