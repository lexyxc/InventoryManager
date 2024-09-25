using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManager
{
    public partial class Form1 : Form
    {
        private List<InventoryItem> inventoryItems = new List<InventoryItem>();
        public Form1()
        {
            InitializeComponent();


            // Set DataGridView settings
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = inventoryItems;

            // Define columns (ID, Name, Category, etc.)
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ItemID", HeaderText = "ID" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Supplier", HeaderText = "Supplier" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Category", HeaderText = "Category" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "Quantity" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "Price" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DateAdded", HeaderText = "Date Added" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReorderLevel", HeaderText = "Reorder" });
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            AddNewItem();
        }

        private void updateItemButton_Click(object sender, EventArgs e)
        {
            UpdateItem();
        }

        private void removeItemButton_Click(object sender, EventArgs e)
        {
            RemoveItem();
        }
        private void AddNewItem()
        {
            InventoryItem newItem = new InventoryItem
            {
                ItemID = inventoryItems.Count + 1, // Simple unique ID generation
                Name = txtItemName.Text,
                Category = txtCategory.Text,
                Quantity = int.Parse(txtQuantity.Text),
                Price = decimal.Parse(txtPrice.Text),
                Supplier = txtSupplier.Text,
                DateAdded = DateTime.Now
            };

            // Add to the list
            inventoryItems.Add(newItem);

            // Update UI (DataGridView or ListView)
            UpdateInventoryList();
        }

        private void UpdateInventoryList()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = inventoryItems;
        }

        private void UpdateItem()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected item using DataBoundItem
                InventoryItem selectedItem = dataGridView1.SelectedRows[0].DataBoundItem as InventoryItem;

                if (selectedItem != null)
                {
                    // Update the item's properties with new values from the form
                    selectedItem.Name = txtItemName.Text;
                    selectedItem.Category = txtCategory.Text;
                    selectedItem.Quantity = int.Parse(txtQuantity.Text);
                    selectedItem.Price = decimal.Parse(txtPrice.Text);
                    selectedItem.Supplier = txtSupplier.Text;

                    // Update the UI
                    UpdateInventoryList();
                }
                else
                {
                    MessageBox.Show("Failed to retrieve the selected item.");
                }
            }
            else
            {
                MessageBox.Show("No item selected.");
            }
        }

        private void RemoveItem()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected item using DataBoundItem
                InventoryItem selectedItem = dataGridView1.SelectedRows[0].DataBoundItem as InventoryItem;

                if (selectedItem != null)
                {
                    // Find and remove the item from the list
                    inventoryItems.Remove(selectedItem);

                    // Update the UI
                    UpdateInventoryList();
                }
                else
                {
                    MessageBox.Show("Failed to retrieve the selected item.");
                }
            }
            else
            {
                MessageBox.Show("No item selected.");
            }
        }
    }
}
