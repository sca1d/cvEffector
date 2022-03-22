using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uidev.Class
{

    // コンポジットモード
    public enum CompositeMode
    {
        normal = 0,
        multiply,
        screen,
        darken,
        lighten,
        linear_dodge_add,
        linear_burn,
        color_dodge,
        color_burn,
        overlay,
        hard_light,
        soft_light,
        vivid_light,
        linear_light,
        pin_light,
        hard_mix,
        difference,
        subtract,
        exclusion,
        divide,
        hue,
        sturation,
        color,
        luminosity
    }

    public struct PointF
    {
        public float x;
        public float y;

        public PointF(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public struct ScaleF
    {
        public float width;
        public float height;

        public ScaleF(float w, float h)
        {
            this.width = w;
            this.height = h;
        }
    }

    public struct VideoProperties
    {

        public PointF center;

        public PointF point;

        public ScaleF scale;

        public double rotation;

        public float alpha;

        public VideoProperties(float cx, float cy, float x, float y, float w, float h, double r, float a)
        {
            this.center = new PointF { x = cx, y = cy };
            this.point = new PointF { x = x, y = y };
            this.scale = new ScaleF { width = w, height = h };
            this.rotation = r;
            this.alpha = a;
        }

    }

    public struct AudioProperties
    {

        public double Level;

        public AudioProperties(double l)
        {
            this.Level = l;
        }
    
    }

}
