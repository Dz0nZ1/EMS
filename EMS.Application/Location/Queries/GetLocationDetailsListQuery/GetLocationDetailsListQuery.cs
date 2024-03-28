using EMS.Application.Common.Dto.Location;
using MediatR;

namespace EMS.Application.Location.Queries.GetLocationDetailsListQuery;

public record GetLocationDetailsListQuery() : IRequest<List<LocationDetailsDto>>;