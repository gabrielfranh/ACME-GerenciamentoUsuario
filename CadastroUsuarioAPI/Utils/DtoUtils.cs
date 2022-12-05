namespace CadastroUsuarioAPI.Utils
{
    public static class DtoUtils
    {
        public static void Copy<TDto, TModel>(this TDto objDto, TModel objModel)
        {
            var props = typeof(TDto).GetProperties();

            foreach (var propDto in props)
            {
                var propModel = typeof(TModel).GetProperty(propDto.Name);
                propModel.SetValue(objModel, propDto.GetValue(objDto));
            }
        }
    }
}
