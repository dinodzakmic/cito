using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cito.Models;
using Xamarin.Forms;

namespace Cito.Framework.Components
{
    public partial class PackageSelector : ContentView
    {
        #region Private properties
        internal Color SelectedColor => (Color)Application.Current.Resources["CitoMain"];


        #endregion
        #region Public properties

        public static readonly BindableProperty SelectedPackageProperty = BindableProperty
            .Create(
                propertyName: nameof(SelectedPackage),
                returnType: typeof(Package),
                declaringType: typeof(PackageSelector),
                defaultValue: Package.StandardPackage,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged:  (b, o, n) =>
                {
                    if((Package)n == null)
                        ((PackageSelector)b).SelectedPackage = Package.StandardPackage;
                });

        public Package SelectedPackage
        {
            get { return (Package) GetValue(SelectedPackageProperty); }
            set { SetValue(SelectedPackageProperty, value); }
        }

        #endregion

        public PackageSelector()
        {
            InitializeComponent();
        }

        #region Methods
        private void StandardTapped(object sender, EventArgs e)
        {
            Standard.BackgroundColor = SelectedColor;
            Professional.BackgroundColor = Color.Transparent;
            Elite.BackgroundColor = Color.Transparent;

            SelectedPackage = Package.StandardPackage;
        }

        private void ProfessionalTapped(object sender, EventArgs e)
        {
            Standard.BackgroundColor = Color.Transparent;
            Professional.BackgroundColor = SelectedColor;
            Elite.BackgroundColor = Color.Transparent;

            SelectedPackage = Package.ProfessionalPackage;
        }

        private void EliteTapped(object sender, EventArgs e)
        {
            Standard.BackgroundColor = Color.Transparent;
            Professional.BackgroundColor = Color.Transparent;
            Elite.BackgroundColor = SelectedColor;

            SelectedPackage = Package.ElitePackage;
        }

        #endregion


    }
}
