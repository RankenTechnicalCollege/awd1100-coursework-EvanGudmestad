using System.Collections.ObjectModel;

namespace LetsPractice
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<int> TestScores { get; set; } = new ObservableCollection<int> { 85, 92, 76, 88, 95 };
        int? selectedScoreIndex = null;

        public int? MaxScore
        {
            get => TestScores.Count > 0 ? TestScores.Max() : null;
        }
        public int? MinScore
        {
            get => TestScores.Count > 0 ? TestScores.Min() : null;
        }
        public double? AverageScore
        {
            get => TestScores.Count > 0 ? TestScores.Average() : null;
        }

        private void UpdateStatistics()
        {
            OnPropertyChanged("MaxScore");
            OnPropertyChanged("MinScore");
            OnPropertyChanged("AverageScore");
        }

        public bool IsUpdateMode
        {
            get => updateMode;
            set
            {
                if (updateMode != value)
                {
                    updateMode = value;
                    OnPropertyChanged("IsUpdateMode");
                }
            }
        }
        private bool updateMode = false;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            TestScores.CollectionChanged += (s, e) => UpdateStatistics();
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            if (int.TryParse(ScoreEntry.Text, out int newScore))
            {
                TestScores.Add(newScore);
                ScoreEntry.Text = string.Empty;
            }
            UpdateStatistics();
        }

        private void OnDeleteScore(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is int score)
            {
                TestScores.Remove(score);
            }
            UpdateStatistics();
        }

        private void OnScoreSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is int selectedScore)
            {
                selectedScoreIndex = TestScores.IndexOf(selectedScore);
                UpdateEntry.Text = selectedScore.ToString();
                IsUpdateMode = true;
            }
        }

        private void OnUpdateClicked(object sender, EventArgs e)
        {
            if (selectedScoreIndex.HasValue && int.TryParse(UpdateEntry.Text, out int updatedScore))
            {
                TestScores[selectedScoreIndex.Value] = updatedScore;
                IsUpdateMode = false;
                ScoresCollectionView.SelectedItem = null;
                UpdateEntry.Text = string.Empty;
                selectedScoreIndex = null;
            }
            UpdateStatistics();
        }

        private void OnCancelUpdateClicked(object sender, EventArgs e)
        {
            IsUpdateMode = false;
            ScoresCollectionView.SelectedItem = null;
            UpdateEntry.Text = string.Empty;
            selectedScoreIndex = null;
        }
    }

}
