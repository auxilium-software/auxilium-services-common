using Casbin.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Casbin
{
    public static class CasbinModelLoader
    {
        public static IModel Load()
        {
            var assembly = typeof(CasbinModelLoader).Assembly;
            var resourceName = "AuxiliumSoftware.AuxiliumServices.Common.casbin_model.conf";

            using var stream = assembly.GetManifestResourceStream(resourceName)
                ?? throw new InvalidOperationException(
                    $"Casbin model resource '{resourceName}' not found in assembly. " +
                    $"Available resources: {string.Join(", ", assembly.GetManifestResourceNames())}");

            using var reader = new StreamReader(stream);
            var model = DefaultModel.Create();
            model.LoadModelFromText(reader.ReadToEnd());
            return model;
        }
    }
}
