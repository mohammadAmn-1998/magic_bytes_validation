using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace magic_bytes_validation
{
	public class FileUploadValidator : AbstractValidator<FileData>
	{

		public FileUploadValidator()
		{

			//check file's first two bytes if they are equal with executable(files with (.exe) extension) files first two bytes that are "4D-5A", "5D-4A"
			
			RuleFor(x => x.File)
				.Must((file, context) =>
					{
						//string type of hexadecimal signature of an executable file
						var executableFilesSignature = new List<string>
						{
							"4D-5A", "5D-4A"
						};

						var binary = new BinaryReader(file.File.OpenReadStream());

						var bytes = binary.ReadBytes(2);

						//string type of hexadecimal signature of an InputFile
						var fileSequenceHex = BitConverter.ToString(bytes);

						foreach (var exeSignature in executableFilesSignature)
							if (string.Equals(fileSequenceHex, exeSignature, StringComparison.OrdinalIgnoreCase))
								return false;
						return true;

					}
				).WithName("FileContent")
				.WithMessage("The File content is executable (.exe) so it is not valid and very dangerous!");


		}

	}
}
