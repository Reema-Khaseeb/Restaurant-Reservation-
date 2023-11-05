﻿using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Services
{
    public class RestaurantService
    {
        private readonly RestaurantReservationDbContext _context;

        public RestaurantService(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task CreateRestaurantAsync(Restaurant restaurant)
        {
            if (restaurant == null)
            {
                throw new ArgumentNullException(nameof(restaurant));
            }

            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task<Restaurant> GetRestaurantAsync(int restaurantId)
        {
            return await _context.Restaurants.FindAsync(restaurantId);
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task UpdateRestaurantAsync(Restaurant restaurant)
        {
            if (restaurant == null)
            {
                throw new ArgumentNullException(nameof(restaurant));
            }

            _context.Restaurants.Update(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRestaurantAsync(int restaurantId)
        {
            var restaurant = await _context.Restaurants.FindAsync(restaurantId);
            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
                await _context.SaveChangesAsync();
            }
        }
    }
}