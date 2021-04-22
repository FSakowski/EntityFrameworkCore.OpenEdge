using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;

namespace EntityFrameworkCore.OpenEdge.Update
{
    public class OpenEdgeSingularModificationCommandBatch : SingularModificationCommandBatch
    {
        public OpenEdgeSingularModificationCommandBatch(ModificationCommandBatchFactoryDependencies dependencies) : 
            base(dependencies)
        {
        }

        protected override RawSqlCommand CreateStoreCommand()
        {
            var commandBuilder = Dependencies.CommandBuilderFactory
                .Create()
                .Append(GetCommandText());

            var parameterValues = new Dictionary<string, object>(GetParameterCount());

            for (var commandIndex = 0; commandIndex < ModificationCommands.Count; commandIndex++)
            {
                var command = ModificationCommands[commandIndex];

                foreach (var columnModification in command.ColumnModifications
                    .OrderBy(cm => cm.IsCondition))
                {
                    if (columnModification.UseCurrentValueParameter)
                    {
                        commandBuilder.AddParameter(columnModification.ParameterName,
                            Dependencies.SqlGenerationHelper.GenerateParameterName(columnModification.ParameterName),
                            columnModification.TypeMapping, columnModification.IsNullable);

                        parameterValues.Add(columnModification.ParameterName, columnModification.Value);
                    }

                    if (columnModification.UseOriginalValueParameter)
                    {
                        commandBuilder.AddParameter(columnModification.OriginalParameterName,
                            Dependencies.SqlGenerationHelper.GenerateParameterName(columnModification.OriginalParameterName),
                            columnModification.TypeMapping, columnModification.IsNullable);

                        parameterValues.Add(columnModification.OriginalParameterName, columnModification.OriginalValue);
                    }
                }
            }

            return new RawSqlCommand(commandBuilder.Build(), parameterValues);
        }
    }
}