import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { provideStore } from '@ngrx/store'; // NgRx store
import { provideEffects } from '@ngrx/effects'; // NgRx effects
import { provideStoreDevtools } from '@ngrx/store-devtools'; // NgRx DevTools

import { routes } from './app.routes';
import { userReducer } from './state/user.reducer'; // Import the user reducer
import { UserEffects } from './state/user.effects'; // Import the effects

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient(),
    provideStore({ user: userReducer }), // Provide the store with user reducer
    provideEffects([UserEffects]), // Provide effects for async operations
    provideStoreDevtools(), // Optionally provide StoreDevTools
  ],
};
