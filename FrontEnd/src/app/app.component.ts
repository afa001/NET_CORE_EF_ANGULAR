import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FrontEnd';

  constructor(private router:Router) { }

  ngOnInit(): void {
  }

  toTransacciones(){
    this.router.navigate(['/transacciones']);
  }

  toCuentas(){
    this.router.navigate(['/cuentas']);
  }
 

}


