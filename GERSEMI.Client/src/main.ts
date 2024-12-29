import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { NavbarComponent } from './app/navbar/navbar.component';
import { FooterComponent } from './app/footer/footer.component';

bootstrapApplication(NavbarComponent, appConfig)
  .catch((err) => console.error(err));

bootstrapApplication(FooterComponent, appConfig)
  .catch((err) => console.error(err));
