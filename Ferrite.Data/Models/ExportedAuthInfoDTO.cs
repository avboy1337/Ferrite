﻿//
//  Project Ferrite is an Implementation of the Telegram Server API
//  Copyright 2022 Aykut Alparslan KOC <aykutalparslan@msn.com>
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Affero General Public License for more details.
//
//  You should have received a copy of the GNU Affero General Public License
//  along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
using System;
using MessagePack;

namespace Ferrite.Data;

[MessagePackObject(true)]
public record ExportedAuthInfoDTO
{
    public long AuthKeyId { get; init; }
    public long UserId { get; init; }
    public string Phone { get; init; } = default!;
    public int PreviousDcId { get; init; }
    public int NextDcId { get; init; }
    public byte[] Data { get; init; } = default!;
}

