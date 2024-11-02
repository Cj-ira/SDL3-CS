using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3;

public static partial class SDL
{
    //extern SDL_DECLSPEC SDL_Texture * SDLCALL SDL_CreateTexture(SDL_Renderer *renderer, SDL_PixelFormat format, SDL_TextureAccess access, int w, int h);
    [LibraryImport(SDLLibrary), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr SDL_CreateTextureFromSurface(IntPtr render, IntPtr surface);

    public static Texture? CreateTexture(SDL.Render render, SDL.Surface surface)
    {
        var ptr = SDL_CreateTextureFromSurface(render.Handle, surface.Handle);

        if (ptr != IntPtr.Zero)
            return new Texture(ptr);

        return null;
    }

    [LibraryImport(SDLLibrary), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr SDL_CreateTexture(IntPtr render, SDL.PixelFormat format, SDL.TextureAccess access, int w, int h);

    public static Texture? CreateTexture(SDL.Render render, SDL.PixelFormat format, SDL.TextureAccess textureAccess, int w, int h)
    {
        var ptr = SDL_CreateTexture(render.Handle, format, textureAccess, w, h);

        if (ptr != IntPtr.Zero)
            return new Texture(ptr);

        return null;
    }

    //extern SDL_DECLSPEC bool SDLCALL SDL_UpdateTexture(SDL_Texture *texture, const SDL_Rect *rect, const void *pixels, int pitch);
    [LibraryImport(SDLLibrary), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(SDLBool)]
    private static partial bool SDL_UpdateTexture(IntPtr texture, in Rect rect, IntPtr pixels, int pitch);

    public static bool UpdateTexture(Texture texture, Rect rect, IntPtr pixels, int pitch) => SDL_UpdateTexture(texture.handle, rect, pixels, pitch);

    //extern SDL_DECLSPEC bool SDLCALL SDL_RenderTexture(SDL_Renderer *renderer, SDL_Texture *texture, const SDL_FRect *srcrect, const SDL_FRect *dstrect);
    [LibraryImport(SDLLibrary), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(SDLBool)]
    private static partial bool SDL_RenderTexture(IntPtr renderer, IntPtr texture, in FRect srcrect, in FRect dtrect);

    public static bool RenderTexture(Render renderer, Texture texture, FRect srcrect, FRect dstrect) => SDL_RenderTexture(renderer.Handle, texture.handle, srcrect, dstrect);

    //extern SDL_DECLSPEC void SDLCALL SDL_DestroyTexture(SDL_Texture *texture);
    [LibraryImport(SDLLibrary), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void SDL_DestroyTexture(IntPtr texture);
    
    public static void DestroyTexture(Texture texture) => SDL_DestroyTexture(texture.handle);

}