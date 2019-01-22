using System;

namespace Car.Domain
{
    public class Color
    {
        public Color(string hue, bool metallic)
        {
            Hue = hue;
            Metallic = metallic;
            if (hue == "white" && !metallic)
            {
                BasicPallete = true;
            }
        }

        public string Hue { get; }
        public bool Metallic { get; }
        public bool BasicPallete { get; }

        public Color Repaint(string hue, bool metallic)
        {
            return new Color(hue, metallic);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Color);
        }

        public bool Equals(Color otherColor)
        {
            if (Object.ReferenceEquals(otherColor, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, otherColor))
            {
                return true;
            }

            if (this.GetType() != otherColor.GetType())
            {
                return false;
            }

            return (Hue == otherColor.Hue) && (Metallic == otherColor.Metallic);
        }

        public static bool operator ==(Color leftColor, Color rightColor)
        {
            if (Object.ReferenceEquals(leftColor, null))
            {
                if (Object.ReferenceEquals(rightColor, null))
                {
                    // null == null = true
                    return true;
                }
                return false;
            }
            return leftColor.Equals(rightColor);
        }

        public static bool operator !=(Color leftColor, Color rightColor)
        {
            return !(leftColor == rightColor);
        }

        public override int GetHashCode()
        {
            return (Hue.GetHashCode() * 0x100000) + (Metallic.GetHashCode() * 0x1000) + BasicPallete.GetHashCode();
        }
    }
}
