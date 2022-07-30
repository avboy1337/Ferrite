// 
// Project Ferrite is an Implementation of the Telegram Server API
// Copyright 2022 Aykut Alparslan KOC <aykutalparslan@msn.com>
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.
// 

using DotNext;

namespace Ferrite.Data;

public interface IKVStore
{
    /// <summary>
    /// Enqueues a put operation.
    /// </summary>
    /// <param name="data">The data to be written.</param>
    /// <param name="keys">Fields of the primary key with the right order.</param>
    /// <returns>True if the operation is successful.</returns>
    public bool Put(byte[] data, params object[] keys);
    /// <summary>
    /// Enqueues a delete operation.
    /// </summary>
    /// <param name="keys">Fields of the primary key with the right order.</param>
    /// <returns></returns>
    public bool Delete(params object[] keys);
    /// <summary>
    /// Enqueues a delete operation.
    /// </summary>
    /// <param name="indexName">Name of the secondary index to be used with the operation.</param>
    /// <param name="keys">Fields of the secondary key with the right order.</param>
    /// <returns></returns>
    public bool Delete(string indexName, params object[] keys);
    /// <summary>
    /// Executes the internal queue as a transaction.
    /// </summary>
    /// <returns>True if the operation is successful.</returns>
    public Task<bool> Commit();
    /// <summary>
    /// Gets a single value for the given key.
    /// </summary>
    /// <param name="keys">Fields of the primary key with the right order.</param>
    /// <returns>The value stored</returns>
    public Task<byte[]> Get(params object[] keys);
    /// <summary>
    /// Gets a single value for the given key.
    /// </summary>
    /// <param name="indexName">Name of the secondary index to be used with the operation.</param>
    /// <param name="keys">Fields of the secondary key with the right order.</param>
    /// <returns>The value stored</returns>
    public Task<byte[]> Get(string indexName, params object[] keys);
    /// <summary>
    /// Gets the matching values for the given key.
    /// </summary>
    /// <param name="keys">Fields of the primary key with the right order.</param>
    /// <returns>Enumerator for the matching values.</returns>
    public IAsyncEnumerable<byte[]> Iterate(params object[] keys);
    /// <summary>
    /// Gets the matching values for the given key.
    /// </summary>
    /// <param name="indexName">Name of the secondary index to be used with the operation.</param>
    /// <param name="keys">Fields of the secondary key with the right order.</param>
    /// <returns>Enumerator for the matching values.</returns>
    public IAsyncEnumerable<byte[]> Iterate(string indexName, params object[] keys);
}