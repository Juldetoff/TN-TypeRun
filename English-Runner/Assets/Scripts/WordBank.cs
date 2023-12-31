using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WordBank : MonoBehaviour
{
    private List<string> tempList = new List<string>()
    {
        "Rock", "Obstacle", "Danger","Squid"
    };
    private List<string> schoolWords = new List<string>()
    {
        "school", "student", "teacher", "class", "lesson", "homework", "test", "exam", "grade"
        , "report", "study", "learn", "book", "notebook", "pen", "pencil", "eraser", "ruler"
        , "calculator", "backpack", "locker", "desk", "chair", "whiteboard", "blackboard", "chalk"
        , "marker", "textbook", "library", "research", "paper", "essay", "project", "presentation"
        , "lecture", "syllabus", "schedule", "deadline", "assignment", "quiz", "diploma", "degree"
        , "campus", "dormitory", "cafeteria", "break", "recess", "lunch", "lunchroom", "cafeteria"
        , "extracurricular", "club", "sports", "basketball", "football", "soccer"
        , "volleyball", "tennis", "swimming", "track", "cross country", "band", "choir", "drama"
        , "art", "dance", "graduation", "commencement", "valedictorian", "salutatorian", "dean"
        , "principal", "guidance counselor", "coach", "auditorium", "gymnasium", "laboratory"
        , "science", "biology", "chemistry", "physics", "math", "algebra", "geometry", "calculus"
        , "history", "geography", "government", "economics", "English", "language"
        , "literature", "poetry", "novel", "short story", "non-fiction", "fiction", "writing", "reading"
    };
    private List<string> sportWords = new List<string>()
    {
        "athlete", "team", "coach", "player", "game", "match", "tournament", "championship", "league"
        , "season", "stadium", "arena", "field", "court", "pitch", "track", "pool", "gymnasium", "weight room"
        , "locker room", "jersey", "uniform", "ball", "equipment", "gear", "shoes", "cleats", "gloves", "helmet"
        , "pads", "net", "goal", "basket", "hoop", "racquet", "club", "bat", "stick", "puck", "scoreboard"
        , "referee", "umpire", "official", "penalty", "foul", "injury", "timeout", "overtime", "halftime"
        , "training", "practice", "drills", "warm-up", "cool-down", "stretching", "endurance", "strength"
        , "speed", "agility", "coordination", "balance", "nutrition", "hydration", "rest", "recovery"
        , "inflammation", "injury prevention", "sportsmanship", "fair play", "respect", "determination"
        , "discipline", "focus", "teamwork", "communication", "leadership", "strategy", "tactics", "offense"
        , "defense", "scoring", "winning", "losing", "challenging", "competition", "victory", "defeat"
        , "record", "personal best", "world record", "medal", "trophy", "champion", "fan", "spectator"
        , "broadcast", "live stream"
    };
    private List<string> infoWords = new List<string>()
    {
        "computer", "keyboard", "mouse", "monitor", "screen", "desktop", "laptop", "tablet", "smartphone"
        , "printer", "scanner", "webcam", "microphone", "headphones", "speakers", "internet", "website"
        , "webpage", "hyperlink", "browser", "search engine", "email", "inbox", "spam", "attachment"
        , "download", "upload", "file", "folder", "directory", "software", "hardware", "program"
        , "application", "operating system", "Windows", "Mac OS", "Linux", "iOS", "Android"
        , "Microsoft Office", "Word", "Excel", "PowerPoint", "database", "SQL", "cloud computing", "server"
        , "client", "firewall", "antivirus", "malware", "virus", "Trojan", "spyware", "adware", "phishing"
        , "hacking", "cybercrime", "encryption", "decryption", "password", "username", "account", "login"
        , "logout", "social media", "Facebook", "Twitter", "Instagram", "LinkedIn", "YouTube", "streaming"
        , "Netflix", "Hulu", "Amazon Prime Video", "Spotify", "iTunes", "gaming", "console", "PC"
        , "mobile gaming", "virtual reality", "augmented reality", "programming", "coding", "HTML"
        , "CSS", "JavaScript", "Python", "Java", "C++", "PHP", "Ruby", "Swift", "debugging", "testing"
        , "version control", "Git", "GitHub"
    };
    private List<string> fishWords = new List<string>(){
        "fish", "shark", "whale", "dolphin", "seal", "sea lion", "otter", "walrus", "octopus", "squid"
        , "jellyfish", "coral", "seahorse", "starfish", "crab", "lobster", "shrimp", "clam", "oyster"
        , "mussel", "sponge", "eel", "ray", "manta ray", "stingray", "turtle", "crocodile", "alligator"
        , "hippopotamus", "manatee", "narwhal", "beluga", "orca", "humpback", "blue whale", "sperm whale"
        , "killer whale", "great white shark", "hammerhead shark", "bull shark", "tiger shark", "lemon shark"
        , "nurse shark", "mantle", "barnacle", "krill", "plankton", "algae", "seaweed", "anemone", "urchin"
        , "cuttlefish", "nautilus", "lobed comb jelly", "box jellyfish", "tilapia"
        , "giant clam", "abalone", "crayfish", "langoustine", "sea cucumber", "sea urchin", "horseshoe crab"
        , "moray eel", "grouper", "barracuda", "tuna", "salmon", "trout", "carp", "catfish", "pike", "swordfish"
        , "marlin", "anglerfish", "deep sea fish", "shoal", "reef", "tide pool", "ocean", "sea", "estuary", "saltwater"
        , "freshwater", "aquarium", "tank", "underwater", "dive", "snorkel", "scuba", "fishing", "angling", "spearfishing"
        , "conservation", "marine biology", "oceanography", "seafloor", "sonar"
    };
    private List<string> foodWords = new List<string>(){
        "fish and chips", "shepherd's pie", "bangers and mash", "roast beef", "Yorkshire pudding", "steak and kidney pie"
        ,"ploughman's lunch", "Cornish pasty", "toad in the hole", "bubble and squeak", "black pudding", "white pudding"
        , "haggis", "neeps and tatties", "Scotch egg", "stargazy pie", "jellied eels", "steak and ale pie", "beef Wellington"
        , "roast lamb", "roast pork", "roast chicken", "beef stew", "corned beef hash", "cottage pie", "lancashire hotpot"
        , "scones", "clotted cream", "jam", "bread and butter pudding", "custard", "trifle", "spotted dick", "Eton mess"
        , "Victoria sponge", "Battenberg cake", "fruitcake", "Christmas pudding", "mince pies", "hot cross buns"
        , "crumpets", "English muffins", "toast", "tea", "coffee", "cider", "ale", "beer", "Gin and Tonic", "Pimms"
        , "whisky", "scotch", "brandy", "port", "sherry", "marmite", "Branston pickle", "piccalilli"
        , "brown sauce", "ketchup", "mayonnaise", "salad cream", "horseradish sauce", "English mustard"
        , "Colman's mustard", "mint sauce", "bread sauce", "apple sauce", "cranberry sauce", "custard sauce"
        , "béchamel sauce", "gravy", "Yorkshire tea", "Twinings tea", "PG Tips tea", "Typhoo tea", "Fortnum and Mason tea"
        , "Hobnobs", "Digestives", "Rich Tea biscuits", "Jammie Dodgers", "Shortbread", "Treacle tart", "Lemon tart"
        , "Banoffee pie", "Apple crumble", "Sticky toffee pudding", "Spotted Dog", "Welsh Rarebit", "cheddar cheese"
        , "Stilton cheese", "red Leicester cheese", "Wensleydale cheese", "cream cheese", "clotted cream ice cream"
    };

    private List<string> animalWords = new List<string>(){
        "dog", "cat", "horse", "cow", "sheep", "goat", "pig", "chicken", "duck", "goose", "turkey", "pigeon"
        , "swan", "parrot", "canary", "hamster", "guinea pig", "rabbit", "ferret", "hedgehog", "rat", "mouse"
        , "squirrel", "fox", "wolf", "coyote", "bear", "lion", "tiger", "leopard", "cheetah", "jaguar", "panther"
        , "elephant", "rhinoceros", "hippopotamus", "giraffe", "zebra", "buffalo", "deer", "moose", "elk", "antelope"
        , "impala", "gazelle", "kangaroo", "koala", "panda", "monkey", "ape", "gorilla", "orangutan", "lemur"
        , "sloth", "armadillo", "porcupine", "skunk", "badger", "weasel", "otter", "seal", "walrus", "whale", "dolphin"
        , "shark", "octopus", "squid", "jellyfish", "crab", "lobster", "shrimp", "clam", "oyster", "snail", "slug"
        , "butterfly", "bee", "wasp", "ant", "spider", "scorpion", "centipede", "millipede", "lizard", "snake", "turtle"
        , "crocodile", "alligator", "frog", "toad", "newt", "salamander", "fish", "salmon", "trout", "tuna", "shark"
        , "eel", "ray", "starfish", "coral", "jellyfish"
    };

    private List<string> workingWords = new List<string>();
    private List<string> hardwords = new List<string>();

    private List<string> originalWords = new List<string>();

    private void Awake()
    {   
        string choice =  PlayerPrefs.GetString("liste");
        List<string> words = ChooseList(choice);
        originalWords = words;
        ResetBank();
    }

    public List<string> ChooseList(string choice){
        if(choice == "school"){
            return schoolWords;
        }
        else if(choice == "info"){
            return infoWords;
        }
        else if(choice == "sport"){
            return sportWords;
        }
        else if(choice == "fish"){
            return fishWords;
        }
        else if(choice == "animal"){
            return animalWords;
        }
        else if(choice == "food"){
            return foodWords;
        }
        else{
            return tempList;
        }
    }


    private void ResetBank(){
        workingWords.Clear();
        workingWords.AddRange(originalWords); //addrange copie 
        ConvertToLower(workingWords);
        Shuffle(workingWords);
    }

    private void Shuffle(List<string> list)
    {
        for(int i=0;i<list.Count; i++)
        {
            int random = Random.Range(i, list.Count);
            string temporary = list[i];

            list[i] = list[random];
            list[random] = temporary;
        }
    }

    private void ConvertToLower(List<string> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            list[i] = list[i].ToLower();
        }
    }

    public string GetWord()
    {
        string newWord = string.Empty;

        if(workingWords.Count > 0)
        {
            newWord = workingWords.Last();
            workingWords.Remove(newWord);
        }
        else{
            ResetBank();
            newWord = workingWords.Last();
            workingWords.Remove(newWord);
        }
        return newWord;
    }

    public string GetHardWord()
    {
        string newWord = string.Empty;

        if(hardwords.Count > 0)
        {
            newWord = hardwords.Last();
            hardwords.Remove(newWord);
        }
        return newWord;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
