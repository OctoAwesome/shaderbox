using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShaderBox
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class ShaderBoxGame : Game
    {
        GraphicsDeviceManager graphics;
        VertexPositionNormalTexture[] vertices;

        BasicEffect effect;
        Effect simple;
        float rotZ = 0f;
        Texture2D wood;

        public ShaderBoxGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            vertices = new VertexPositionNormalTexture[36];

            // Vorne (-y)
            vertices[00] = new VertexPositionNormalTexture(new Vector3(-0.5f, -0.5f, +0.5f), new Vector3(0, -1f, 0), new Vector2(0f, 0f));
            vertices[01] = new VertexPositionNormalTexture(new Vector3(+0.5f, -0.5f, +0.5f), new Vector3(0, -1f, 0), new Vector2(1f, 0f));
            vertices[02] = new VertexPositionNormalTexture(new Vector3(-0.5f, -0.5f, -0.5f), new Vector3(0, -1f, 0), new Vector2(0f, 1f));
            vertices[03] = new VertexPositionNormalTexture(new Vector3(+0.5f, -0.5f, +0.5f), new Vector3(0, -1f, 0), new Vector2(1f, 0f));
            vertices[04] = new VertexPositionNormalTexture(new Vector3(+0.5f, -0.5f, -0.5f), new Vector3(0, -1f, 0), new Vector2(1f, 1f));
            vertices[05] = new VertexPositionNormalTexture(new Vector3(-0.5f, -0.5f, -0.5f), new Vector3(0, -1f, 0), new Vector2(0f, 1f));

            // Hinten (+y)
            vertices[06] = new VertexPositionNormalTexture(new Vector3(+0.5f, +0.5f, +0.5f), new Vector3(0, +1f, 0), new Vector2(0f, 0f));
            vertices[07] = new VertexPositionNormalTexture(new Vector3(-0.5f, +0.5f, +0.5f), new Vector3(0, +1f, 0), new Vector2(1f, 0f));
            vertices[08] = new VertexPositionNormalTexture(new Vector3(+0.5f, +0.5f, -0.5f), new Vector3(0, +1f, 0), new Vector2(0f, 1f));
            vertices[09] = new VertexPositionNormalTexture(new Vector3(-0.5f, +0.5f, +0.5f), new Vector3(0, +1f, 0), new Vector2(1f, 0f));
            vertices[10] = new VertexPositionNormalTexture(new Vector3(-0.5f, +0.5f, -0.5f), new Vector3(0, +1f, 0), new Vector2(1f, 1f));
            vertices[11] = new VertexPositionNormalTexture(new Vector3(+0.5f, +0.5f, -0.5f), new Vector3(0, +1f, 0), new Vector2(0f, 1f));

            // Rechts (+x)
            vertices[12] = new VertexPositionNormalTexture(new Vector3(+0.5f, -0.5f, +0.5f), new Vector3(+1f, 0, 0), new Vector2(0f, 0f));
            vertices[13] = new VertexPositionNormalTexture(new Vector3(+0.5f, +0.5f, +0.5f), new Vector3(+1f, 0, 0), new Vector2(1f, 0f));
            vertices[14] = new VertexPositionNormalTexture(new Vector3(+0.5f, -0.5f, -0.5f), new Vector3(+1f, 0, 0), new Vector2(0f, 1f));
            vertices[15] = new VertexPositionNormalTexture(new Vector3(+0.5f, +0.5f, +0.5f), new Vector3(+1f, 0, 0), new Vector2(1f, 0f));
            vertices[16] = new VertexPositionNormalTexture(new Vector3(+0.5f, +0.5f, -0.5f), new Vector3(+1f, 0, 0), new Vector2(1f, 1f));
            vertices[17] = new VertexPositionNormalTexture(new Vector3(+0.5f, -0.5f, -0.5f), new Vector3(+1f, 0, 0), new Vector2(0f, 1f));

            // Links (-x)
            vertices[18] = new VertexPositionNormalTexture(new Vector3(-0.5f, +0.5f, +0.5f), new Vector3(-1f, 0, 0), new Vector2(0f, 0f));
            vertices[19] = new VertexPositionNormalTexture(new Vector3(-0.5f, -0.5f, +0.5f), new Vector3(-1f, 0, 0), new Vector2(1f, 0f));
            vertices[20] = new VertexPositionNormalTexture(new Vector3(-0.5f, +0.5f, -0.5f), new Vector3(-1f, 0, 0), new Vector2(0f, 1f));
            vertices[21] = new VertexPositionNormalTexture(new Vector3(-0.5f, -0.5f, +0.5f), new Vector3(-1f, 0, 0), new Vector2(1f, 0f));
            vertices[22] = new VertexPositionNormalTexture(new Vector3(-0.5f, -0.5f, -0.5f), new Vector3(-1f, 0, 0), new Vector2(1f, 1f));
            vertices[23] = new VertexPositionNormalTexture(new Vector3(-0.5f, +0.5f, -0.5f), new Vector3(-1f, 0, 0), new Vector2(0f, 1f));

            // Oben (+z)
            vertices[24] = new VertexPositionNormalTexture(new Vector3(-0.5f, +0.5f, +0.5f), new Vector3(0, 0, +1f), new Vector2(0f, 0f));
            vertices[25] = new VertexPositionNormalTexture(new Vector3(+0.5f, +0.5f, +0.5f), new Vector3(0, 0, +1f), new Vector2(1f, 0f));
            vertices[26] = new VertexPositionNormalTexture(new Vector3(-0.5f, -0.5f, +0.5f), new Vector3(0, 0, +1f), new Vector2(0f, 1f));
            vertices[27] = new VertexPositionNormalTexture(new Vector3(+0.5f, +0.5f, +0.5f), new Vector3(0, 0, +1f), new Vector2(1f, 0f));
            vertices[28] = new VertexPositionNormalTexture(new Vector3(+0.5f, -0.5f, +0.5f), new Vector3(0, 0, +1f), new Vector2(1f, 1f));
            vertices[29] = new VertexPositionNormalTexture(new Vector3(-0.5f, -0.5f, +0.5f), new Vector3(0, 0, +1f), new Vector2(0f, 1f));

            // Unten (-z)
            vertices[30] = new VertexPositionNormalTexture(new Vector3(-0.5f, -0.5f, -0.5f), new Vector3(0, 0, -1f), new Vector2(0f, 0f));
            vertices[31] = new VertexPositionNormalTexture(new Vector3(+0.5f, -0.5f, -0.5f), new Vector3(0, 0, -1f), new Vector2(1f, 0f));
            vertices[32] = new VertexPositionNormalTexture(new Vector3(-0.5f, +0.5f, -0.5f), new Vector3(0, 0, -1f), new Vector2(0f, 1f));
            vertices[33] = new VertexPositionNormalTexture(new Vector3(+0.5f, -0.5f, -0.5f), new Vector3(0, 0, -1f), new Vector2(1f, 0f));
            vertices[34] = new VertexPositionNormalTexture(new Vector3(+0.5f, +0.5f, -0.5f), new Vector3(0, 0, -1f), new Vector2(1f, 1f));
            vertices[35] = new VertexPositionNormalTexture(new Vector3(-0.5f, +0.5f, -0.5f), new Vector3(0, 0, -1f), new Vector2(0f, 1f));

            effect = new BasicEffect(GraphicsDevice);
            simple = Content.Load<Effect>("simple");

            wood = Content.Load<Texture2D>("wood");
        }

        protected override void Update(GameTime gameTime)
        {
            rotZ += (float)gameTime.ElapsedGameTime.TotalSeconds;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Matrix worldViewProj = Matrix.CreateRotationZ(rotZ) * Matrix.CreateRotationX(rotZ / 2);
            worldViewProj *= Matrix.CreateLookAt(new Vector3(0, -3, 0f), new Vector3(0, 0, 0f), Vector3.UnitZ);
            worldViewProj *= Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, GraphicsDevice.Viewport.AspectRatio, 1f, 100f);

            simple.Parameters["WorldViewProj"].SetValue(worldViewProj);
            simple.Parameters["Wood"].SetValue(wood);

            simple.Parameters["AmbientIntensity"].SetValue(0.3f);
            simple.Parameters["AmbientColor"].SetValue(Color.White.ToVector4());

            simple.Parameters["DiffuseColor"].SetValue(Color.White.ToVector4());
            simple.Parameters["DiffuseIntensity"].SetValue(0.7f);
            simple.Parameters["DiffuseDirection"].SetValue(new Vector3(1, 1, 1));

            simple.CurrentTechnique.Passes[0].Apply();

            GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, vertices, 0, 12);

            base.Draw(gameTime);
        }
    }
}
