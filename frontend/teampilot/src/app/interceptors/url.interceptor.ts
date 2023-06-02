import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpInterceptor,
} from '@angular/common/http';

@Injectable()
export class UrlInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler) {
    let url: string = '';

    if (window.location.hostname == 'teampilotapp.azurewebsites.net') {
      const requestPath = req.url.replace(/^.*\/\/[^\/]+/, '');
      url = 'https://teampilotapi.azurewebsites.net' + requestPath;
    }

    const authRequest = req.clone({
      url: url,
    });

    // send cloned request with header to the next handler.
    return next.handle(authRequest);
  }
}
