import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ClientPortal';

  constructor(
    private readonly router: Router
  ){
    
  }
  selectionClass(url: string) {
    return this.router.url.indexOf(url) >= 0 ? 'bold-black' : '';
  }
}
