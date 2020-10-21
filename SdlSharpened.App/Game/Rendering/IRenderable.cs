using SdlSharpened;

namespace SdlSharpened.App
{
    public interface IRenderable
    {
        public void Render(Renderer renderer, Camera camera);
    }
}