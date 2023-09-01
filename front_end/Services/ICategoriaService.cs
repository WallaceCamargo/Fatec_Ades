using front_end.Models;

namespace front_end.Services;

public interface ICategoriaService
{
    Task<IEnumerable<CategoriaViewModel>> GetCategorias();
    Task<CategoriaViewModel> GetCategoriaPorId(int id);
    Task<CategoriaViewModel> CriaCategoria(CategoriaViewModel categoriaVM);
    Task<bool> AtualizaCateoria(int id, CategoriaViewModel categoriaVM);
    Task<bool> DeletaCategoria(int id);
}