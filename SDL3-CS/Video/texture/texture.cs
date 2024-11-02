namespace SDL3;

public static partial class SDL
{
    public class Texture
    {
        internal IntPtr handle;

        public Texture(IntPtr texture)
        {
            this.handle = texture;
        }

        /// <summary>
        /// Returns false should the object being passed in is null, or if the <paramref name="obj"/> is not comparable to this.
        /// Returns true should this match <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj) => obj is null ? false : (obj is Texture other) && this.handle == other.handle;

        public static bool operator ==(Texture? left, Texture? right)
        {
            // I probably could have written this super neat, but it is a simple comparison operation on two classes and I don't have time for that.
            if (left is null)
            {
                if (right is null)
                    return true;

                return false;
            }

            if (right is null) 
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(Texture? left, Texture? right) => !(left == right);

        public override int GetHashCode() => handle.GetHashCode();
    }
}