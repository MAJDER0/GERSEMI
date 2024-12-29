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
  // Existing state for desktop sub-menu
  SubNavState: string = 'hidden';
  isMouseOverSklepButton: boolean = false;
  leftButtonArea: boolean = false;
  items: string[] = ['Wszystkie', 'Bluzy', 'Koszulki', 'Wyprzedaż'];

  // **New State for Mobile Menu**
  isMobileMenuOpen: boolean = false;

  // **New State for Mobile "Sklep+" Submenu**
  isSklepSubMenuOpen: boolean = false;

    /**
   * Returns the total number of items in the `items` array.
   */
    getItemsCount(): number {
      return this.items.length;
    }

  /**
   * Splits the items array into chunks of specified size.
   * Useful for displaying items in columns.
   */
  chunkArray(arr: string[], size: number): string[][] {
    const results: string[][] = [];
    for (let i = 0; i < arr.length; i += size) {
      results.push(arr.slice(i, i + size));
    }
    return results;
  }

  /**
   * Handles the state when the mouse leaves the "Sklep" button area.
   */
  leftButton(left: boolean): void {
    this.leftButtonArea = left;
  }

  /**
   * Controls the visibility of the desktop sub-menu.
   */
  ShowSubNav(state: string): void {
    if (!this.isMouseOverSklepButton || this.leftButtonArea == true) {
      this.SubNavState = state;
    }
  }

  /**
   * Toggles the mouse over state for the "Sklep" button.
   */
  toggleMouseOverSklepButton(enter: boolean): void {
    this.isMouseOverSklepButton = enter;
    console.log("State: ", this.SubNavState, " isMouseOverSklepButton: ", this.isMouseOverSklepButton, "LeftButtonArea: ", this.leftButtonArea);
  }

  /**
   * Hides the sub-menu when the mouse leaves the sub-menu area.
   */
  hideSubNavOnMouseLeave(event: MouseEvent): void {
    const target = event.relatedTarget as HTMLElement;
    if (!target || (!target.classList.contains('sklep-button') && !target.closest('#subNav'))) {
      this.SubNavState = 'hidden';
      this.isMouseOverSklepButton = false;
    }
  }

  /**
   * **New Function:** Toggles the mobile sub-menu visibility.
   * Called when the menu icon is clicked.
   */
  toggleMobileMenu(): void {
    this.isMobileMenuOpen = !this.isMobileMenuOpen;
    console.log("Mobile Menu State: ", this.isMobileMenuOpen);
  }

  /**
   * **New Function:** Toggles the "Sklep+" submenu in mobile menu.
   */
  toggleSklepSubMenu(): void {
    this.isSklepSubMenuOpen = !this.isSklepSubMenuOpen;
    console.log("Sklep+ Submenu State: ", this.isSklepSubMenuOpen);
  }

  /**
   * **Optional:** Closes the mobile menu when a menu item is clicked.
   * You can bind this method to the click event of mobile menu items.
   */
  closeMobileMenu(): void {
    this.isMobileMenuOpen = false;
    console.log("Mobile Menu Closed");
  }
}
