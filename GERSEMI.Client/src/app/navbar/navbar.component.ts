import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  SubNavState: string = 'hidden';
  isMouseOverSklepButton: boolean = false;
  leftButtonArea : boolean = false;
   items: string[] = ['Wszystkie', 'Bluzy', 'Koszulki', 'Wyprzedaż'];

   chunkArray(arr: string[], size: number): string[][] {
    const results: string[][] = [];
    for (let i = 0; i < arr.length; i += size) {
      results.push(arr.slice(i, i + size));
    }
    return results;
  }

  leftButton(left:boolean): void {
    this.leftButtonArea = left;
  }

  ShowSubNav(state: string): void {
    if (!this.isMouseOverSklepButton || this.leftButtonArea == true) {
      this.SubNavState = state;
    }
  }

  toggleMouseOverSklepButton(enter: boolean): void {
    this.isMouseOverSklepButton = enter;
    console.log("State: ",this.SubNavState," isMouseOverSklepButton: ", this.isMouseOverSklepButton,"LeftButtonArea: ", this.leftButtonArea);
  }

  hideSubNavOnMouseLeave(event: MouseEvent): void {
    const target = event.relatedTarget as HTMLElement;
    if (!target || (!target.classList.contains('sklep-button') && !target.closest('#subNav'))) {
      this.SubNavState = 'hidden';
      this.isMouseOverSklepButton = false;
    }
  }
}