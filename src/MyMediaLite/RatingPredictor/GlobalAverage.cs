// Copyright (C) 2010 Zeno Gantner, Steffen Rendle
// Copyright (C) 2011 Zeno Gantner
//
// This file is part of MyMediaLite.
//
// MyMediaLite is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// MyMediaLite is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with MyMediaLite.  If not, see <http://www.gnu.org/licenses/>.

using MyMediaLite.Data;

namespace MyMediaLite.RatingPredictor
{
    /// <summary>Uses the average rating value over all ratings for prediction</summary>
    /// <remarks>
    /// This engine does NOT support online updates.
    /// </remarks>
    public class GlobalAverage : Memory
    {
		private double global_average = 0;

        /// <inheritdoc/>
        public override void Train()
		{
			foreach (RatingEvent r in Ratings.All)
				global_average += r.rating;
			global_average /= Ratings.All.Count;
		}

        /// <inheritdoc/>
		public override bool CanPredict(int user_id, int item_id)
		{
			return true;
		}

        /// <inheritdoc/>
        public override double Predict(int user_id, int item_id)
        {
            return global_average;
        }

		/// <inheritdoc/>
		public override void SaveModel(string filename)
		{
			// do nothing
		}

		/// <inheritdoc/>
		public override void LoadModel(string filename)
		{
			Train();
		}

		/// <summary>returns the name of the method</summary>
		/// <returns>A <see cref="System.String"/></returns>
		public override string ToString()
		{
			return "GlobalAverage";
		}
    }
}